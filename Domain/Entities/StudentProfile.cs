using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public ApplicationUser User { get; set; }
    }
}
