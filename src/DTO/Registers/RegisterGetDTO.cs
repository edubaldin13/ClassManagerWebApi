using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace class_management_web_api.src.DTO.Register
{
    public class RegisterGetDTO
    {
        public Guid RegisterId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } 
    }
}