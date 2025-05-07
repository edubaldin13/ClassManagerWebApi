using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.Teacher;
using ClassManagementWebApi.src.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _managerRepository;
        public TeacherController(ITeacherRepository managerRepository){
            _managerRepository = managerRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<TeacherGetDTO>> GetTeachers()
        {
            return _managerRepository.GetTeachers();
        }
        [HttpGet("no-course")]
        public Task<IEnumerable<TeacherWithoutCourseGetDTO>> GetTeachersWithoutCourse()
        {
            return _managerRepository.GetTeachersWithoutCourse();
        }
        [HttpPatch("{teacherId}/{courseId}")]
        public Task<GenericResponse> UpdateTeacherCourse([FromRoute] int teacherId , [FromRoute] int courseId)
        {
            return _managerRepository.UpdateTeacherCourse(teacherId, courseId);
        }
    }
}
