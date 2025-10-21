using Domain.Entities;
using OnlineCourse.Web_Project.ViewModels;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers
{
    public static class CreateCourseAutoMapper
    {
        public static Course ConvertCreateCourseViewModelToCourse(CreateCourseViewModel courseViewModel,TeacherProfile teacher)
        {
            var cousre = new Course
            {
                TeacherProfileId = teacher.Id,
                Title = courseViewModel.Title,
                Description = courseViewModel.Description,
                Price = courseViewModel.Price,
                IsDeleted = false,
                IsActive = false,
                CreatedDate = DateTime.Now,
            };

            return cousre;
        }
    }
}
