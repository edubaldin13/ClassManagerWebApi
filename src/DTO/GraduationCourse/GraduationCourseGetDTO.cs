using AutoMapper;
using class_management_web_api.src.Entities;
namespace class_management_web_api.src.DTO.GraduationCourse
{
    [AutoMap(typeof(Entities.GraduationCourse))]

    public class GraduationCourseGetDTO
    {
        public Guid GraduationCourseId { get; set; }
        public required string Name { get; set; }
        // public Guid ManagerId { get; set; }
        public Entities.Manager Manager { get; set; }
        public string ManagerName { get; set; }
        //horário de inicio do periodo curso de graduação
        public DateTime ClassStartingHour { get; set; }
        //horário de encerramento do periodo curso de graduação
        public DateTime ClassClosingHour { get; set; }
        //quantidade de aulas do curso de graduação
        public int ClassesQuantity { get; set; }
        //tempo de duração das aulas, usei int para depoiiis transformar em minutos
        public int ClassDuration { get; set; }
        public IEnumerable<int>? Teachers { get; set; }
    }
}