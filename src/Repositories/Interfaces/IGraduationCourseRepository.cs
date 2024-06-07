using class_management_web_api.src.DTO;
using class_management_web_api.src.DTO.GraduationCourse;
using class_management_web_api.src.Requests;

namespace class_management_web_api.src.Repositories
{
    public interface IGraduationCourseRepository
    {
        public Task<IEnumerable<GraduationCourseGetDTO>> GetGraduationCourses ();
        public Task<GenericResponse> PostGraduationCourses(GraduationCoursePostRequest request);
        public Task<GenericResponse> DeleteGraduationCourse(Guid id);
    }
}