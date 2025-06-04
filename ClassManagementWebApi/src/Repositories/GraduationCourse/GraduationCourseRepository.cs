using System.Diagnostics;
using System.Net;
using AutoMapper;
using ClassManagementWebApi.Entities;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.Contexts;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.ClassSubject;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.DTO.Teacher;
using ClassManagementWebApi.src.Entities;
using ClassManagementWebApi.src.@enum;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Requests;
using ClassManagementWebApi.src.Requests.GraduationCourse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
namespace ClassManagementWebApi.Repositories
{
    public class GraduationCourseRepository : IGraduationCourseRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public GraduationCourseRepository(ApplicationDbContext context
                             , IMapper mapper
                             , IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GraduationCourseGetDTO> GetGraduationCourseById(int id)
        {
            var record = await _context.GraduationCourses.FirstOrDefaultAsync(gc => gc.GraduationCourseId.Equals(id));
            if (record == null)
            {
                return null;
            }
            // var groupedClassTimes = await _context.ClassTimes
            //     .Where(cl => cl.GraduationCourseId.Equals(id))
            //     .OrderByDescending(cl => cl.Start) // Order by TeacherIdDay numerically
            //     .ThenByDescending(cl => cl.TeacherIdDay) // Then order by Start time
            //     .GroupBy(ct => ct.TeacherIdDay)
            //     .ToListAsync();

            var groupedClassTimes = await _context.ClassTimes
            .Where(cl => cl.GraduationCourseId.Equals(id))
            .GroupBy(ct => ct.TeacherIdDay)
            .Select(group => group
                .OrderBy(ct => ct.Start) // Order within each group by Start
                .ToList())
            .ToListAsync();

            List<ClassTime> recordGraduationClassTime = groupedClassTimes
                .SelectMany(group => group.Select(item => new ClassTime
                {
                    GraduationCourseId = item.GraduationCourseId,
                    TeacherIdDay = item.TeacherIdDay,
                    Start = item.Start,
                    End = item.End,
                    ClassSubjectId = item.ClassSubjectId,
                    TeacherId = item.TeacherId,
                    Id = item.Id
                }))
                .ToList();
            if (recordGraduationClassTime.IsNullOrEmpty())
            {
                var enumValues = Enum.GetValues(typeof(TeacherIdDayEnum)).Cast<TeacherIdDayEnum>();
                foreach (var enumValue in enumValues)
                {
                    await _context.ClassTimes.AddAsync(new ClassTime
                    {
                        GraduationCourseId = id,
                        TeacherIdDay = enumValue // Replace EnumProperty with the actual property name
                    });
                }
                await _context.ClassTimes.AddAsync(new ClassTime
                {
                    GraduationCourseId = id
                });
                await _context.SaveChangesAsync();
            }

            var classTimes = recordGraduationClassTime;// await _context.ClassTimes.Where(cl => cl.GraduationCourseId == id).ToListAsync();
            foreach (var classTime in classTimes)
            {
                if (classTime.TeacherId != null)
                {
                    classTime.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == classTime.TeacherId);
                }
                if (classTime.ClassSubjectId != null)
                {
                    classTime.ClassSubject = await _context.ClassSubjects.FirstOrDefaultAsync(t => t.ClassSubjectId == classTime.ClassSubjectId);
                }
            }

            return new GraduationCourseGetDTO
            {
                GraduationCourseId = record.GraduationCourseId,
                Name = record.Name,
                ClassDuration = record.ClassDuration,
                ClassTimes = classTimes
            };
        }

        public async Task<GenericResponse> DeleteGraduationCourse(int id)
        {
            try
            {
                var record = await _context.GraduationCourses.FirstOrDefaultAsync(r => r.GraduationCourseId.Equals(id));
                if (record is null)
                {
                    return new GenericResponse()
                    {
                        IsSuccess = false,
                        Status = 404
                    };
                }
                var classTimes = await _context.ClassTimes.Where(cl => cl.GraduationCourseId.Equals(id)).ToListAsync();
                _context.Remove(classTimes);
                _context.Remove(record);
                await _context.SaveChangesAsync();
                return new GenericResponse()
                {
                    IsSuccess = true
                };
            }
            catch (System.Exception ex)
            {
                return new GenericResponse()
                {
                    IsSuccess = false
                };
            }
        }

        public async Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses()
        {
            var record = await _context.GraduationCourses
                                       .Include(x => x.Manager)
                                       .Select(gc => new
                                       {
                                           gc.GraduationCourseId,
                                           gc.Name,
                                           ManagerName = gc.Manager.Name,
                                           gc.ClassDuration,
                                           gc.End,
                                           gc.Start
                                       })
                                       .ToListAsync();
            List<GraduationCourseGetDTO> result = [];
            foreach (var item in record)
            {
                result.Add(
                new GraduationCourseGetDTO
                {
                    GraduationCourseId = item.GraduationCourseId,
                    Name = item.Name,
                    ManagerName = item.ManagerName,
                    ClassDuration = item.ClassDuration,
                }
                );
            }
            return result;
        }

        public async Task<GenericResponse> PostGraduationCourses(GraduationCoursePostRequest request)
        {
            try
            {
                var recordGraduationCourse = new GraduationCourse
                {
                    Name = request.Name,
                    ManagerId = request.ManagerId,
                    ClassDuration = request.ClassDuration
                };
                await _context.AddAsync(recordGraduationCourse);
                await _context.SaveChangesAsync();
                var generatedId = recordGraduationCourse.GraduationCourseId; // The ID is now populated

                DateTime horarioDuracao;
                var horarioInicio = request.ClassStart;
                var horarioFim = request.ClassEnd;
                //recebe o tamanho em minutos do intervalo
                var horarioInicioIntervaloEmMinutos = (horarioFim - horarioInicio).TotalMinutes % request.ClassDuration;

                var somaHorariosEnquantoHorarioDuracaoMenorQueMinutosEntreHoraioInicioEFim = request.ClassStart.AddMinutes(request.ClassDuration);

                DateTime horarioFimIntervalo = horarioInicio.AddMinutes(horarioInicioIntervaloEmMinutos);

                var horarioFIMSUB = horarioFim.Subtract(horarioInicio).TotalMinutes;
                var aulaAnteriorIntervalo = horarioFIMSUB / request.ClassDuration;
                int index = 0;
                while (request.ClassDuration < horarioFIMSUB)
                {
                    DateTime horarioInicioCERTO = horarioInicio.AddMinutes(request.ClassDuration);
                    DateTime horarioFimCERTO = horarioFim.AddMinutes(request.ClassDuration);

                    if (index == double.Floor(aulaAnteriorIntervalo / 2))
                    {
                        horarioInicio = horarioInicio.AddMinutes(horarioInicioIntervaloEmMinutos);
                        // horarioFim = horarioFim.AddMinutes(horarioInicioIntervaloEmMinutos);
                    }
                    var enumValues = Enum.GetValues(typeof(TeacherIdDayEnum)).Cast<TeacherIdDayEnum>();
                    foreach (var enumValue in enumValues)
                    {
                        await _context.ClassTimes.AddAsync(new ClassTime
                        {
                            GraduationCourseId = recordGraduationCourse.GraduationCourseId,
                            TeacherIdDay = enumValue, // Replace EnumProperty with the actual property name
                            Start = horarioInicio.ToUniversalTime(),
                            End = horarioInicio.AddMinutes(request.ClassDuration).ToUniversalTime()
                        });
                    }

                    // horarioDuracao = request.ClassStart.AddMinutes(request.ClassDuration);
                    // if (horarioDuracao > request.ClassEnd)
                    // {
                    //     break;
                    // }
                    // request.ClassStart = horarioDuracao;

                    horarioInicio = horarioInicio.AddMinutes(request.ClassDuration);
                    horarioFim = horarioFim.AddMinutes(request.ClassDuration);
                    horarioFIMSUB = horarioFIMSUB - request.ClassDuration;
                    index++;
                }

                await _context.SaveChangesAsync();

                return new GenericResponse
                {
                    IsSuccess = true
                };
            }
            catch (System.Exception ex)
            {
                // TODO
                return new GenericResponse
                {
                    IsSuccess = false,
                    Status = 400
                };
            }
        }

        public async Task<GetCourseDataByGraduationCourseIdRequest> GetCourseDataByGraduationCourseId(int courseId, int? horarioId, int? addType, int teacherDayId)
        {
            GetCourseDataByGraduationCourseIdRequest record = new();
            record.Teachers = new List<TeacherGetDTO>();
            #region Lista Horario
            if (addType == 0)
            {
                var teachersList = await _context.Teachers.FromSqlInterpolated($@"SELECT t.*
                                            FROM ""Teachers"" t
                                            LEFT JOIN ""ClassTimes"" ct 
                                                ON ct.""GraduationCourseId"" = {courseId}
                                            AND ct.""TeacherIdDay"" = {teacherDayId}
                                            AND ct.""TeacherId"" != t.""TeacherId""").ToListAsync();
                foreach (var teacher in teachersList)
                {

                    record.Teachers.Add(new TeacherGetDTO
                    {
                        TeacherId = teacher.TeacherId,
                        Name = teacher.Name
                    });
                }

            }
            #endregion

            #region Lista Matéria
            if (addType == 1)
            {
                record.ClassSubjects = await _context.ClassSubjects.FromSqlInterpolated($@"SELECT cs.""ClassSubjectId"" , cs.""Name"", cs.""ManagerId"", cs.""TeacherId""
                                            FROM ""ClassSubjects"" cs
                                            LEFT JOIN ""ClassTimes"" ct 
                                                ON ct.""GraduationCourseId"" = {courseId}
                                            AND ct.""TeacherIdDay"" = {teacherDayId}
                                            AND ct.""ClassSubjectId"" != cs.""ClassSubjectId""").ToListAsync();
                // foreach (var item in listaClassSubject)
                // {
            }
            // }
            #endregion

            return record;
        }

        public async Task<HttpStatusCode> AddCourseData(PostClassSubjectOrTeacherRequest request)
        {
            //         {
            //     public int GraduationCourseId { get; set; }
            //     public int? TeacherId { get; set; }
            //     public int? ClassSubjectId { get; set; }
            //     public int TeacherDayId { get; set; }
            //     public int? HourId { get; set; }
            // }
            if (request.TeacherId != null)
            {
                // var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == request.TeacherId);
                if (request.HourId != null)
                {
                    var existingClassTime = await _context.ClassTimes.FirstOrDefaultAsync(ct =>
                    ct.GraduationCourseId == request.GraduationCourseId &&
                    ct.TeacherIdDay == (TeacherIdDayEnum)request.TeacherDayId &&
                    ct.TeacherId == request.TeacherId);

                    if (existingClassTime != null)
                    {
                        existingClassTime.Start = request.HourId.HasValue ? DateTime.UtcNow.AddHours(request.HourId.Value) : DateTime.UtcNow;
                        existingClassTime.End = request.HourId.HasValue ? DateTime.UtcNow.AddHours(request.HourId.Value + 1) : DateTime.UtcNow.AddHours(1);
                        _context.ClassTimes.Update(existingClassTime);
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    var classTimesWithoutTeacherByTeacherIdDay = await _context.ClassTimes.Where(r => r.GraduationCourseId == request.GraduationCourseId && r.TeacherIdDay == request.TeacherDayId).ToListAsync();
                    foreach (var classTime in classTimesWithoutTeacherByTeacherIdDay)
                    {
                        classTime.TeacherId = request.TeacherId;
                        _context.ClassTimes.Update(classTime);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            if (request.ClassSubjectId != null)
            {
                // var classSubject = await _context.ClassSubjects.FirstOrDefaultAsync(cs => cs.ClassSubjectId == request.ClassSubjectId);
                if (request.HourId != null)
                {
                    var existingClassTime = await _context.ClassTimes.FirstOrDefaultAsync(ct =>
                    ct.GraduationCourseId == request.GraduationCourseId &&
                    ct.TeacherIdDay == (TeacherIdDayEnum)request.TeacherDayId &&
                    ct.ClassSubjectId == request.ClassSubjectId);

                    if (existingClassTime != null)
                    {
                        existingClassTime.Start = request.HourId.HasValue ? DateTime.UtcNow.AddHours(request.HourId.Value) : DateTime.UtcNow;
                        existingClassTime.End = request.HourId.HasValue ? DateTime.UtcNow.AddHours(request.HourId.Value + 1) : DateTime.UtcNow.AddHours(1);
                        _context.ClassTimes.Update(existingClassTime);
                    }
                    else
                    {
                        return HttpStatusCode.NotFound;
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    var classTimesWithoutClassSubjectByTeacherIdDay = await _context.ClassTimes.Where(r => r.GraduationCourseId == request.GraduationCourseId && r.TeacherIdDay == request.TeacherDayId).ToListAsync();
                    foreach (var classTime in classTimesWithoutClassSubjectByTeacherIdDay)
                    {
                        classTime.ClassSubjectId = request.ClassSubjectId;
                        _context.ClassTimes.Update(classTime);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            return HttpStatusCode.OK;
        }
    }
}