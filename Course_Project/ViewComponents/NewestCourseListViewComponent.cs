using Domain.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Web_Project.Mappers;

namespace OnlineCourse.Web_Project.ViewComponents
{
    public class NewestCourseListViewComponent : ViewComponent
    {
        private readonly ICourseService courseService;

        public NewestCourseListViewComponent(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var courses = await courseService.GetAllAsync();
            courses = courses.OrderBy(c => c.CreatedDate).Take(5).ToList();
            var coursesViewModels = CourseToViewModelMapper.CourseToCourseViewModel(courses);
            return View("NewestCourseListView", coursesViewModels);
        }
    }
}
