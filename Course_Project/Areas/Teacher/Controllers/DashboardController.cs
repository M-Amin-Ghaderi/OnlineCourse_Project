using Domain.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Web_Project.Services;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Areas.Teachers.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class DashboardController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly UserManager<ApplicationUser> userManager;
        public DashboardController(ITeacherService teacherService, UserManager<ApplicationUser> userManager)
        {
            this.teacherService = teacherService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) { return NotFound("User Not Found"); }
            var teacher = await teacherService.GetTeacherByUserIdAsync(user.Id);
            if (teacher == null) return NotFound("Teacher Profile Not Found");

            var courseCount = await teacherService.GetTeacherCourseCountAsync(user.Id);
            var studentCount = await teacherService.GetTeacherStudentCountAsync(user.Id);
            var totalIncome = await teacherService.GetTeacherTotalIncomeAsync(user.Id);

            ViewData["CourseCount"] = courseCount;
            ViewData["StudentsCount"] = studentCount;
            ViewData["TotalIncome"] = totalIncome.ToString("");

            return View(teacher);
        }
        public IActionResult Courses()
        {
            return View();
        }
    }
}
