using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_management_web_api.src.Entities;

namespace class_management_web_api.src.Requests
{
    public class GraduationCoursePostRequest
    {
        public Guid GraduationCourseId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public int ClassesQuantity { get; set; }
        public int ClassDuration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}