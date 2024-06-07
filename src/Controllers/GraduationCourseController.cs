using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.GraduationCourse;
using class_management_web_api.src.Repositories;
using class_management_web_api.src.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GraduationCourseController : Controller
    {
        private readonly IGraduationCourseRepository _managerRepository;
        public GraduationCourseController(IGraduationCourseRepository managerRepository){
            _managerRepository = managerRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses()
        {
            return _managerRepository.GetGraduationCourses();
        }
        [HttpPost()]
        public Task<GenericResponse> PostGraduationCourse(GraduationCoursePostRequest request)
        {
            return _managerRepository.PostGraduationCourses(request);
        }
        [HttpDelete("{id}")]
        public Task<GenericResponse> DeleteGraduationCourse([FromRoute] Guid id){
            return _managerRepository.DeleteGraduationCourse(id);
        }
    }
}
