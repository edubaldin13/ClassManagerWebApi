using ClassManagementWebApi.Requests.Teacher;
using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.Teacher;

namespace ClassManagementWebApi.src.Repositories
{
    public interface ITeacherRepository
    {
        public Task<IEnumerable<TeacherGetDTO>> GetTeachers ();
        public Task<GenericResponse> UpdateTeacherCourse(TeacherPostRequest teacher);
        public Task<IEnumerable<TeacherWithoutCourseGetDTO>> GetTeachersWithoutCourse();
    }
}