using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.Entities.Teacher
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int TeacherId { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(254)]
        [MinLength(3)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(254)]
        [MinLength(3)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(9)]
        public string? CPF { get; set; }
        public string? TeacherDoc { get; set; }
        public  IEnumerable<ClassSubject>? ClassSubjects { get; set; }
        public int? GraduationCourseId { get; set; }
        public GraduationCourse? GraduationCourse { get; set; }
        public string Role { get; set; } = Roles.Teacher.ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
