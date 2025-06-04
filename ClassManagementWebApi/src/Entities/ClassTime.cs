using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.Entities;


// using ClassManagementWebApi.Entities.Teacher;
// using ClassManagementWebApi.src.Entities;

using ClassManagementWebApi.src.@enum;

namespace ClassManagementWebApi.Entities
{
    public class ClassTime
    {
        [Key]
        public int Id { get; set; }

        public TeacherIdDayEnum TeacherIdDay { get; set;}
        public int? TeacherId { get; set; }

        public Teacher.Teacher? Teacher { get; set; }

        [ForeignKey("GraduationCourse")]
        public int GraduationCourseId { get; set; }
        [Required]
        public GraduationCourse GraduationCourse { get; set; }
        public int? ClassSubjectId { get; set; }
        public ClassSubject? ClassSubject { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}