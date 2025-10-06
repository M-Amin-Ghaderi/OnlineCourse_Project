using Microsoft.AspNetCore.Mvc;

namespace OnlineCourse.Web_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
