using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace class_management_web_api.src.DTO.Manager
{
    public class ManagerGetDTO
    {
        public Guid ManagerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
    }
}