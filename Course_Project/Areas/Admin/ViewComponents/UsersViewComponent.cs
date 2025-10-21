using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Areas.Admin.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersViewComponent(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await userManager.Users.ToListAsync();
            Dictionary<string, string> roles = new Dictionary<string, string>();
            var noneAdminUsers = new List<ApplicationUser>();
            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, "Teacher"))
                {
                    roles.Add(user.Id, "Teacher");
                    noneAdminUsers.Add(user);
                }
                else if (await userManager.IsInRoleAsync(user, "Student"))
                {
                    roles.Add(user.Id, "Student");
                    noneAdminUsers.Add(user);
                }
            }
            var usersWithRoles = new UsersWithRoles
            {
                ApplicationUsers = noneAdminUsers,
                Roles = roles
            };
            return View("GetAllUsersView", usersWithRoles);
        }
    }
}
