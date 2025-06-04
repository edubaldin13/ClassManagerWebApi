// using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.DTO.ClassSubject;
using ClassManagementWebApi.src.Entities;
using ClassManagementWebApi.src.@enum;
namespace ClassManagementWebApi.src.Requests.GraduationCourse
{
    public class PostClassSubjectOrTeacherRequest
    {
        public int GraduationCourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassSubjectId { get; set; }
        public TeacherIdDayEnum TeacherDayId { get; set; }
        public int? HourId { get; set; }
    }
}