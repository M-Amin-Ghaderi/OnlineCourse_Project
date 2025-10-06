using Microsoft.AspNetCore.Identity;

namespace OnlineCourse_Project.Models
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
