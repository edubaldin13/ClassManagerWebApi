using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_management_web_api.src.Entities;

namespace class_management_web_api.src.Requests
{
    public class ClassSubjectPostRequest
    {
        public Guid ClassSubjectId { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}