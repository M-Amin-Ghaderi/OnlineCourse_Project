using System.ComponentModel.DataAnnotations;

namespace OnlineCourse_Project.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}
