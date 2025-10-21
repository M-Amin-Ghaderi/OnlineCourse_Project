using Domain.Entities;
using OnlineCourse.Web_Project.ViewModels.Course;
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
                TeacherProfileId = course.TeacherProfileId,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ImageUrl = course.ImageUrl,
                CreatedDate = course.CreatedDate,
                IsActive = course.IsActive,
                IsDeleted = course.IsDeleted,
                videos = course.Videos,
            };

            return cousreViewModel;
        }

        public static List<CourseViewModel> CourseToCourseViewModel(List<Course> courseList)
        {
            var cousreViewModelList =  new List<CourseViewModel>();
            foreach (var course in courseList)
            {
                var cousreViewModel = new CourseViewModel
                {
                    Id = course.Id,
                    TeacherProfileId = course.TeacherProfileId,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    IsDeleted= course.IsDeleted,
                    IsActive= course.IsActive,
                    CreatedDate= course.CreatedDate,
                    ImageUrl = course.ImageUrl,
                    videos = course.Videos,
                    
                };
                cousreViewModelList.Add(cousreViewModel);
            }

            return cousreViewModelList;
        }
        public static Course CourseViewModelToCourse(CourseViewModel courseViewModel)
        {
            var cousre = new Course
            {
                Id = courseViewModel.Id,
                TeacherProfileId = courseViewModel.TeacherProfileId,
                Title = courseViewModel.Title,
                Description = courseViewModel.Description,
                Price = courseViewModel.Price,
                IsDeleted = courseViewModel.IsDeleted,
                IsActive = courseViewModel.IsActive,
                CreatedDate = courseViewModel.CreatedDate,
                ImageUrl = courseViewModel.ImageUrl,
                Videos = courseViewModel.videos,

            };

            return cousre;
        }

        public static List<Course> CourseViewModelToCourse(List<CourseViewModel> CourseViewModelList)
        {
            var cousreList = new List<Course>();
            foreach (var courseViewModel in CourseViewModelList)
            {
                var cousre = new Course
                {
                    Id = courseViewModel.Id,
                    TeacherProfileId = courseViewModel.TeacherProfileId,
                    Title = courseViewModel.Title,
                    Description = courseViewModel.Description,
                    Price = courseViewModel.Price,
                    IsDeleted = courseViewModel.IsDeleted,
                    IsActive = courseViewModel.IsActive,
                    CreatedDate = courseViewModel.CreatedDate,
                    ImageUrl = courseViewModel.ImageUrl,
                    Videos = courseViewModel.videos,
                };
                cousreList.Add(cousre);
            }

            return cousreList;
        }
    }
}
