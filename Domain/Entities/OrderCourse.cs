using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }


        public Order Order { get; set; }
        public Course Course { get; set; }


    }
}
