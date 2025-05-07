using ClassManagementWebApi.src.DTO;
using ClassManagementWebApi.src.DTO.Teacher;

namespace ClassManagementWebApi.src.Repositories
{
    public interface ITeacherRepository
    {
        public Task<IEnumerable<TeacherGetDTO>> GetTeachers ();
        public Task<GenericResponse> UpdateTeacherCourse(int courseId, int teacherId);
        public Task<IEnumerable<TeacherWithoutCourseGetDTO>> GetTeachersWithoutCourse();
    }
}