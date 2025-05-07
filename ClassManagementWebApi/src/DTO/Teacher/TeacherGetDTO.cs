using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementWebApi.src.DTO.Teacher
{
    public class TeacherGetDTO
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? GraduationCourseName { get; set; }
        public int? GraduationCourseId { get; set; }
    }
}