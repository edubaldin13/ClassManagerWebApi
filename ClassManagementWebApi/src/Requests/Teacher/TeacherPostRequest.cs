using ClassManagementWebApi.src.@enum;

namespace ClassManagementWebApi.Requests.Teacher
{
    public class TeacherPostRequest
    {
        public TeacherIdDayEnum TeacherIdDay { get; set; }
        public int? TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}