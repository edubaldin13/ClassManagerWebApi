using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.GraduationCourse;
using ClassManagementWebApi.src.Requests;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IGraduationCourseRepository
    {
        public Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses ();
        public Task<GenericResponse> PostGraduationCourses(GraduationCoursePostRequest request);
        public Task<GenericResponse> DeleteGraduationCourse(int id);
    }
}