using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.ViewModels
{
    public class UsersWithRoles
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public Dictionary<string,string> Roles { get; set; }
    }
}
