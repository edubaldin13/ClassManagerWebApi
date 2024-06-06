using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_management_web_api.src.Entities
{
    public class ClassSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClassSubjectId { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
        public Guid ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
