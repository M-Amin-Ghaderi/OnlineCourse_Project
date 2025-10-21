using Domain.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Web_Project.Mappers;
using OnlineCourse.Web_Project.Mappers.CourseMappers;
using OnlineCourse.Web_Project.Services;
using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse.Web_Project.ViewModels.Course;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Areas.Teachers.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IVideoService videoService;
        private readonly ITeacherService teacherService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CoursesController(UserManager<ApplicationUser> userManager, ICourseService courseService, ITeacherService teacherService, IVideoService videoService)
        {
            _userManager = userManager;
            this.courseService = courseService;
            this.teacherService = teacherService;
            this.videoService = videoService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) { return NotFound("User Not Found"); }
            var teacher = await teacherService.GetTeacherByUserIdAsync(user.Id);
            var coursesList = teacher.Courses.ToList();
            var courseListViewModels = CourseToViewModelMapper.CourseToCourseViewModel(coursesList);
            return View(courseListViewModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user is null) { return NotFound("Teacher Not Found"); }
                var teacher = await teacherService.GetTeacherByUserIdAsync(user.Id);
                var course = CreateCourseAutoMapper.ConvertCreateCourseViewModelToCourse(courseViewModel, teacher);


                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(courseViewModel.Image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await courseViewModel.Image.CopyToAsync(stream);
                }
                course.ImageUrl = fileName;
                await courseService.AddAsync(course);
                await courseService.SaveChangesAsync();
                return RedirectToAction("Index", "Courses");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(courseViewModel);
        }
        public async Task<IActionResult> Details(string id)
        {
            var decodedId = BitConverter.ToInt32(Convert.FromBase64String(id));
            var user = await _userManager.GetUserAsync(User);
            if (user == null) { return NotFound("User Not Found"); }
            var teacher = await teacherService.GetTeacherByUserIdAsync(user.Id);

            var course = await courseService.GetByIdAsync(decodedId);
            if (course == null) return NotFound();

            if (course.TeacherProfileId != teacher.Id)
            {
                return BadRequest();
            }
            
            var courseViewModel = CourseDetailsViewModelMapper.CourseToCourseDetailsViewModel(course);
            return View(courseViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            int decodedId = BitConverter.ToInt32(Convert.FromBase64String(id));
            var user = await _userManager.GetUserAsync(User);
            if (user == null) { return NotFound("User Not Found"); }
            var teacher = await teacherService.GetTeacherByUserIdAsync(user.Id);

            var course = await courseService.GetByIdAsync(decodedId);
            if (course == null) { return NotFound(); }

            if (course.TeacherProfileId != teacher.Id)
            {
                return BadRequest();
            }

            var courseEditViewModel = CourseEditViewModelMapper.CourseToCourseEditViewModel(course);
            return View(courseEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CourseEditViewModel courseEditViewModel)
        {
            if (id != courseEditViewModel.Id)
            {
                return NotFound();
            }


            var course = CourseEditViewModelMapper.CourseEditViewModelToCourse(courseEditViewModel);
            if (courseEditViewModel.Image != null)
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(courseEditViewModel.Image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await courseEditViewModel.Image.CopyToAsync(stream);
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", course.ImageUrl.TrimStart('/')));
                }
                course.ImageUrl = fileName;
            }
            if (ModelState.IsValid)
            {
                courseService.Update(course);
                await courseService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course == null) { return NotFound(); }
            var courseVideos = await videoService.GetAllByCourseIdAsync(course.Id);
            if (courseVideos.Any())
            {
                foreach (var item in courseVideos)
                {
                    await videoService.DeleteAsync(item.Id);
                    //System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos", item.Url.TrimStart('/')));
                }
            }
            await courseService.DeleteAsync(course.Id);
            await courseService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
