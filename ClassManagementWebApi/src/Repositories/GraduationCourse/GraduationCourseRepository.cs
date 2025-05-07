using AutoMapper;
using ClassManagementWebApi.src.Contexts;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.Requests;
using Microsoft.EntityFrameworkCore;
namespace ClassManagementWebApi.src.Repositories.GraduationCourse
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

        public async Task<GenericResponse> DeleteGraduationCourse(int id)
        {
            try
            {
                var record = await _context.GraduationCourses.FirstOrDefaultAsync(r => r.GraduationCourseId.Equals(id));

                //validar se existe algum professor com o id do curso
                var professoresCadastradosNesseCurso = await _context.Teachers
                    .Where(p => p.GraduationCourseId == id)
                    .ToListAsync();
                if (professoresCadastradosNesseCurso.Any())
                {
                    foreach (var item in professoresCadastradosNesseCurso)
                    {
                        item.GraduationCourseId = null;
                        _context.Update(item);
                    }
                }
                //update nesses professores passando courseId como nulo

                //
                _context.Remove(record);
                await _context.SaveChangesAsync();
                return new GenericResponse(){
                    IsSuccess = true
                };
            }
            catch (System.Exception ex)
            {
                return new GenericResponse(){
                    IsSuccess = false
                };
                 // TODO
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
            List<GraduationCourseGetDTO> result = [] ;
            foreach (var item in record)
            {
                result.Add(
                new GraduationCourseGetDTO{
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
                var record = new Entities.GraduationCourse
                {
                    Name = request.Name,
                    ManagerId = request.ManagerId,
                    ClassDuration = 40
                };
                await _context.AddAsync(record);
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
                    IsSuccess = false
                };
            }
        }
    }
}