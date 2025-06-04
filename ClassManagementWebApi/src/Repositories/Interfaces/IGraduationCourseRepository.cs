using System.Net;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.Requests;
using ClassManagementWebApi.src.Requests.GraduationCourse;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IGraduationCourseRepository
    {
        public Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses();
        public Task<GenericResponse> PostGraduationCourses(GraduationCoursePostRequest request);
        public Task<GenericResponse> DeleteGraduationCourse(int id);
        public Task<GraduationCourseGetDTO> GetGraduationCourseById(int id);
        public Task<GetCourseDataByGraduationCourseIdRequest> GetCourseDataByGraduationCourseId(int courseId, int? horarioId, int? addType, int teacherDayId);
        public Task<HttpStatusCode> AddCourseData(PostClassSubjectOrTeacherRequest request);
    }
}