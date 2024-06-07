using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace class_management_web_api.src.DTO
{
    public class GenericResponse
    {
        public bool IsCreated { get; set; }
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
    }
}