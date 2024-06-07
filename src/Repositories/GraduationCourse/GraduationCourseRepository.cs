using AutoMapper;
using class_management_web_api.src.Contexts;
using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.GraduationCourse;
using class_management_web_api.src.Requests;
using Microsoft.EntityFrameworkCore;
namespace class_management_web_api.src.Repositories.GraduationCourse
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

        public async Task<GenericResponse> DeleteGraduationCourse(Guid id)
        {
            try
            {
                var record = await _context.GraduationCourses.FirstOrDefaultAsync(r => r.GraduationCourseId.Equals(id));
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
                                            gc.ClassesQuantity,
                                            gc.ClassDuration,
                                            gc.CreatedAt,
                                            gc.UpdatedAt
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
                     ClassesQuantity = item.ClassesQuantity,
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
                    ClassDuration = request.ClassDuration,
                    ClassesQuantity = request.ClassesQuantity,
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