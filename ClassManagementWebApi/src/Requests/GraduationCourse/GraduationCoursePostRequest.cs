using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.src.Requests
{
    public class GraduationCoursePostRequest
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public DateTime ClassStart { get; set; }
        public DateTime ClassEnd { get; set; }
        public int ClassDuration { get; set; }
    }
}