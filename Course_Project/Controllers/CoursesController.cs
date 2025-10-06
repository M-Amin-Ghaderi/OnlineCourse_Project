using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Controllers
{
    public class CoursesController : Controller
    {
        public readonly OnlineCourse_DbContext _context;

        public CoursesController(OnlineCourse_DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var coursesList = await _context.Courses.ToListAsync();
            return View(coursesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _context.Courses.Include(c => c.Videos).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = new Course()
                {
                    Id = courseViewModel.Id,
                    Title = courseViewModel.Title,
                    Description = courseViewModel.Description,
                    Price = courseViewModel.Price.Value,
                };
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Courses");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(courseViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) { return NotFound(); }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) { return NotFound(); }
            var courseVideos = await _context.Videos.Where(v => v.CourseId == course.Id).ToListAsync();
            if (courseVideos.Any())
            {
                foreach (var item in courseVideos)
                {
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", item.Url.TrimStart('/')));
                }
            }
            _context.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
