using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.src.Requests
{
    public class RegisterPostRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public String Role { get; set; }
        public int IsActive { get; set; } = 0;
    }
}