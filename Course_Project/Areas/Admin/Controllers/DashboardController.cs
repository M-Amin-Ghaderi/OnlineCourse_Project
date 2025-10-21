using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly OnlineCourse_DbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public DashboardController(OnlineCourse_DbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var noneAdminUsers = new List<ApplicationUser>();
            foreach (var user in users)
            {
                if (!await userManager.IsInRoleAsync(user, "Admin"))
                {
                    noneAdminUsers.Add(user);
                }
            }

            ViewData["CourseCount"] = dbContext.Courses.Count();
            ViewData["UsersCount"] = noneAdminUsers.Count;
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }
}
