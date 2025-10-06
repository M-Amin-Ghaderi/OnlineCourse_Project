using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers
{
    public static class CourseToViewModelMapper
    {
        public static CourseViewModel CourseToCourseViewModel(Course course)
        {
            var cousreViewModel = new CourseViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
            };

            return cousreViewModel;
        }

        public static List<CourseViewModel> CourseListToCourseViewModelList(List<Course> courseList)
        {
            var cousreViewModelList =  new List<CourseViewModel>();
            foreach (var course in courseList)
            {
                var cousreViewModel = new CourseViewModel
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                };
                cousreViewModelList.Add(cousreViewModel);
            }

            return cousreViewModelList;
        }
    }
}
