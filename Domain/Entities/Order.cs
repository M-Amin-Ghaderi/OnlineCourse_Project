using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse_Project.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<OrderCourse> OrderCourses { get; set; }

    }
}
