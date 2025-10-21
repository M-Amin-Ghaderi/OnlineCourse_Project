using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Areas.Teacher.ViewComponents
{
    public class CoursesViewComponent : ViewComponent
    {
        private readonly OnlineCourse_DbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public CoursesViewComponent(OnlineCourse_DbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            if (currentUser == null) { return View(); }
            var teacher = context.Teachers.FirstOrDefault(t => t.UserId == currentUser.Id);
            var courses = context;
            return View();
        }
    }
}
