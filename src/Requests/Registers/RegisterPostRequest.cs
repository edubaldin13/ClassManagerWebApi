using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_management_web_api.src.Entities;

namespace class_management_web_api.src.Requests
{
    public class RegisterPostRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public Roles? Role { get; set; }
    }
}