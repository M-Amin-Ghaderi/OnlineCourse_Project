using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Web_Project.Mappers;


namespace OnlineCourse.Web_Project.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public readonly OnlineCourse_DbContext dbContext;

        public AdminController(OnlineCourse_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }



    }
}
