using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Web_Project.Mappers;
using OnlineCourse.Web_Project.ViewModels;

namespace OnlineCourse.Web_Project.Areas.Admin.ViewComponents
{
    public class CoursesViewComponent  : ViewComponent
    {
        public readonly OnlineCourse_DbContext dbContext;

        public CoursesViewComponent(OnlineCourse_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var courses = await dbContext.Courses.ToListAsync();
            var coursesViewModels = CourseToViewModelMapper.CourseListToCourseViewModelList(courses);
            return View("GetAllCoursesView", coursesViewModels);
        }
    }
}
