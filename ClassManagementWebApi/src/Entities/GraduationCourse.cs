using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.DTO.GraduationCourse;

namespace ClassManagementWebApi.src.Entities
{
    [AutoMap(typeof(GraduationCourseGetDTO))]
    public class GraduationCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GraduationCourseId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int ClassDuration { get; set; }
        public IEnumerable<Teacher>? Teachers { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ClassQuantity { get; set; }
    }
}
