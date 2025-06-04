
namespace ClassManagementWebApi.src.DTO.ClassSubject
{
    public class ClassSubjectGetDTO
    {
        public int ClassSubjectId { get; set; }
        public Teacher.TeacherGetDTO? Teacher { get; set; }
        public Entities.Manager? Manager { get; set; }
        public string? Name { get; set; }
    }
}