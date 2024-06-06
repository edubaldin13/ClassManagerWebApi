using class_management_web_api.src.Entities;
namespace class_management_web_api.src.DTO.ClassSubject
{
    public class ClassSubjectGetDTO
    {
        public Guid ClassSubjectId { get; set; }
        public Entities.Teacher? Teacher { get; set; }
        public Entities.Manager? Manager { get; set; }
        public string? Name { get; set; }
    }
}