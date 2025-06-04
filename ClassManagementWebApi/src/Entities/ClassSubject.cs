using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClassManagementWebApi.Entities.Teacher;

namespace ClassManagementWebApi.src.Entities
{
    public class ClassSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassSubjectId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public IEnumerable<Teacher>? Teacher { get; set; }
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }
    }
}
