// using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.DTO.ClassSubject;
using ClassManagementWebApi.src.DTO.Teacher;
using ClassManagementWebApi.src.Entities;
namespace ClassManagementWebApi.src.Requests.GraduationCourse
{
    public class GetCourseDataByGraduationCourseIdRequest
    {
        public int GraduationCourseId { get; set; }
        public List<TeacherGetDTO>? Teachers { get; set; }
        public List<ClassSubject>? ClassSubjects { get; set; }
    }
}