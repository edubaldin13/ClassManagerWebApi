using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
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
        public Task<GenericResponse> DeleteGraduationCourse([FromRoute] int id){
            return _managerRepository.DeleteGraduationCourse(id);
        }
    }
}
