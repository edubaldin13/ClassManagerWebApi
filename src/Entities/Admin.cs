using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_management_web_api.src.Entities
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(254)]
        [MinLength(3)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(254)]
        [MinLength(3)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(9)]
        public string? CPF { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
