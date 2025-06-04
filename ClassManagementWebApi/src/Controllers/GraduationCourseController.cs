using System.Net;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.@enum;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Requests;
using ClassManagementWebApi.src.Requests.GraduationCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ClassManagementWebApi.src.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GraduationCourseController : Controller
    {
        private readonly IGraduationCourseRepository _graduationCourseRepository;
        public GraduationCourseController(IGraduationCourseRepository managerRepository)
        {
            _graduationCourseRepository = managerRepository;
        }
        [HttpGet()]
        public Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses()
        {
            return _graduationCourseRepository.GetGraduationCourses();
        }
        [HttpPost()]
        public Task<GenericResponse> PostGraduationCourse(GraduationCoursePostRequest request)
        {
            return _graduationCourseRepository.PostGraduationCourses(request);
        }
        [HttpDelete("{id}")]
        public Task<GenericResponse> DeleteGraduationCourse([FromRoute] int id)
        {
            return _graduationCourseRepository.DeleteGraduationCourse(id);
        }

        [HttpGet("{id}")]
        public async Task<GraduationCourseGetDTO> GetGraduationCourseById([FromRoute] int id)
        {
            return await _graduationCourseRepository.GetGraduationCourseById(id);
        }

        [HttpGet("{courseId}/horarios/adicionar/{teacherDayId}/{addType}")]
        public async Task<GetCourseDataByGraduationCourseIdRequest> GetCourseDataByGraduationCourseId([FromRoute] int courseId, [FromRoute] int addType, [FromRoute] int teacherDayId, [FromQuery] int? horarioId)
        {
            // await this.courseService.get(`/${this.courseId}/horarios/${this.horarioId}/adicionar/${this.addType}/${this.teacherDayId}`)
            Console.WriteLine("esse eh o curso id", courseId);
            Console.WriteLine("esse eh o teacherDAYiD id", teacherDayId);
            return await _graduationCourseRepository.GetCourseDataByGraduationCourseId(courseId, horarioId, addType, teacherDayId);
        }

        [HttpPost("{courseId}/adicionar/{teacherDayId}")]
        public async Task<HttpStatusCode> AddCourseData([FromRoute] int courseId, [FromRoute] TeacherIdDayEnum teacherDayId ,[FromBody]  PostClassSubjectOrTeacherRequest request)
        {
            request.GraduationCourseId = courseId;
            request.TeacherDayId = teacherDayId;
            return await _graduationCourseRepository.AddCourseData(request);
        }

    }
}
