using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourse_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public TeacherProfile TeacherProfile { get; set; }
        public StudentProfile StudentProfile { get; set; }


    }
}
