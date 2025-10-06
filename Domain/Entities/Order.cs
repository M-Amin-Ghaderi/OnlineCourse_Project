using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse_Project.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CourseId { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public User? AppUser { get; set; }

        public Course Course { get; set; }

    }
}
