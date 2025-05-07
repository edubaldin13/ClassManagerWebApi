using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.src.Requests
{
    public class GraduationCoursePostRequest
    {
        public int GraduationCourseId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;
    }
}