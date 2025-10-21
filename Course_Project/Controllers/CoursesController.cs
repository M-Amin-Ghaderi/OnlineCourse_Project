using Domain.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineCourse.Web_Project.Mappers;
using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Controllers
{
    public class CoursesController : Controller
    {
        public readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var coursesList = await courseService.GetAllAsync();
            var courseListViewModel = CourseToViewModelMapper.CourseToCourseViewModel(coursesList);
            return View(courseListViewModel);
        }

    }
}
