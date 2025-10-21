using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse_Project.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int TeacherProfileId { get; set; }
        public TeacherProfile Teacher { get; set; }
        public ICollection<Video> Videos { get; set; } = new List<Video>();
        public ICollection<OrderCourse> OrderCourses { get; set; }


    }
}
