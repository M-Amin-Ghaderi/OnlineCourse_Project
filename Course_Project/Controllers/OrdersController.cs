using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OnlineCourse_DbContext context;
        private readonly UserManager<User> userManager;
        public OrdersController(OnlineCourse_DbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Buy(int courseId)
        {

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bool alreadyPurchased = await context.Orders.AnyAsync(o => o.CourseId == courseId && o.UserId == user.Id);
            if (alreadyPurchased)
            {
                TempData["Message"] = "شما قبلاً این دوره را خریداری کرده‌اید.";
                return RedirectToAction("Index", "Courses");
            }

            var order = new Order
            {
                CourseId = courseId,
                UserId = user.Id,
                PurchaseDate = DateTime.Now
            };

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            TempData["Message"] = "خرید با موفقیت انجام شد!";
            return RedirectToAction("MyCourses");
        }

        public async Task<IActionResult> MyCourses()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var myCourses = await context.Orders
                .Where(o => o.UserId == user.Id)
                .Include(o => o.Course)
                .ToListAsync();
            return View(myCourses);
        }

        public async Task<IActionResult> Videos(int courseId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bool hasAccess = await context.Orders.AnyAsync(o => o.CourseId == courseId && o.UserId == user.Id);
            if (!hasAccess)
            {
                TempData["Message"] = "شما به این دوره دسترسی ندارید. لطفاً ابتدا آن را خریداری کنید.";
                return RedirectToAction("Index", "Courses");
            }
            var videos = await context.Videos
                .Where(v => v.CourseId == courseId)
                .ToListAsync();
            ViewBag.CourseId = courseId;

            ViewBag.CourseTitle = (await context.Courses.FirstOrDefaultAsync(c => c.Id == courseId))?.Title;
            return View(videos);
        }
    }
}
