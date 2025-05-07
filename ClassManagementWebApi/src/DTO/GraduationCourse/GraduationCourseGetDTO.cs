using AutoMapper;
using ClassManagementWebApi.src.Entities;
namespace ClassManagementWebApi.src.DTO.GraduationCourse
{
    [AutoMap(typeof(Entities.GraduationCourse))]

    public class GraduationCourseGetDTO
    {
        public int GraduationCourseId { get; set; }
        public required string Name { get; set; }
        // public int ManagerId { get; set; }
        public Entities.Manager Manager { get; set; }
        public string ManagerName { get; set; }
        //horário de inicio do periodo curso de graduação
        public DateTime Start { get; set; }
        //horário de encerramento do periodo curso de graduação
        public DateTime End { get; set; }
        //tempo de duração das aulas, usei int para depoiiis transformar em minutos
        public int ClassDuration { get; set; }
        public IEnumerable<int>? Teachers { get; set; }
    }
}