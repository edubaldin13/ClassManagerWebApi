using ClassManagementWebApi.src.Entities;
namespace ClassManagementWebApi.src.DTO.ClassSubject
{
    public class ClassSubjectGetDTO
    {
        public int ClassSubjectId { get; set; }
        public Entities.Teacher? Teacher { get; set; }
        public Entities.Manager? Manager { get; set; }
        public string? Name { get; set; }
    }
}