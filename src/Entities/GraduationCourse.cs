using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using class_management_web_api.src.DTO.GraduationCourse;

namespace class_management_web_api.src.Entities
{
    [AutoMap(typeof(GraduationCourseGetDTO))]
    public class GraduationCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GraduationCourseId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
        //horário de inicio do periodo curso de graduação
        // public DateTime? ClassStartingHour { get; set; }
        //horário de encerramento do periodo curso de graduação
        // public DateTime? ClassClosingHour { get; set; }
        //quantidade de aulas do curso de graduação
        public int ClassesQuantity { get; set; }
        //tempo de duração das aulas, usei int para depoiiis transformar em minutos
        public int ClassDuration { get; set; }
        public IEnumerable<Teacher>? Teachers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
