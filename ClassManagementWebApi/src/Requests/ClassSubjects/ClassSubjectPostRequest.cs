using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassManagementWebApi.src.Entities;

namespace ClassManagementWebApi.src.Requests
{
    public class ClassSubjectPostRequest
    {
        public int ClassSubjectId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}