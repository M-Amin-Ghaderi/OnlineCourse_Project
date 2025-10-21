using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCourse.Web_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
