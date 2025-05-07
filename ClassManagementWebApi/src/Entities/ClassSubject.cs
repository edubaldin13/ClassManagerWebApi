using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManagementWebApi.src.Entities
{
    public class ClassSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassSubjectId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }
    }
}
