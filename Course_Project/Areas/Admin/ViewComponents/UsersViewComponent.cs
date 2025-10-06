using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Areas.Admin.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public UsersViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var noneAdminUsers = new List<User>();
            foreach (var user in users)
            {
                if (!await userManager.IsInRoleAsync(user,"Admin"))
                {
                    noneAdminUsers.Add(user);
                }
            }

            return View("GetAllUsersView", noneAdminUsers);
        }
    }
}
