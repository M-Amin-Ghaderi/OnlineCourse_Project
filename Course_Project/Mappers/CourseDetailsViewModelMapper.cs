using OnlineCourse.Web_Project.ViewModels.CourseViewModels;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers
{
    public class CourseDetailsViewModelMapper
    {
        public static CourseDetailsViewModel CourseToCourseDetailsViewModel(Course course)
        {
            string encodedId = Convert.ToBase64String(BitConverter.GetBytes(course.Id));
            var courseDetailsViewModel = new CourseDetailsViewModel
            {
                Id = encodedId,
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

            return courseDetailsViewModel;
        }

        public static List<CourseDetailsViewModel> CourseToCourseDetailsViewModel(List<Course> courseList)
        {
            var courseDetailsViewModelList = new List<CourseDetailsViewModel>();
            foreach (var course in courseList)
            {
                string encodedId = Convert.ToBase64String(BitConverter.GetBytes(course.Id));
                var courseDetailsViewModel = new CourseDetailsViewModel
                {
                    Id = encodedId,
                    TeacherProfileId = course.TeacherProfileId,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    IsDeleted = course.IsDeleted,
                    IsActive = course.IsActive,
                    CreatedDate = course.CreatedDate,
                    ImageUrl = course.ImageUrl,
                    videos = course.Videos,

                };
                courseDetailsViewModelList.Add(courseDetailsViewModel);
            }

            return courseDetailsViewModelList;
        }

        public static Course CourseDetailsViewModelToCourse(CourseDetailsViewModel courseDetailsViewModel)
        {
            int decodedId = BitConverter.ToInt32(Convert.FromBase64String(courseDetailsViewModel.Id));
            var cousre = new Course
            {
                Id = decodedId,
                TeacherProfileId = courseDetailsViewModel.TeacherProfileId,
                Title = courseDetailsViewModel.Title,
                Description = courseDetailsViewModel.Description,
                Price = courseDetailsViewModel.Price,
                IsDeleted = courseDetailsViewModel.IsDeleted,
                IsActive = courseDetailsViewModel.IsActive,
                CreatedDate = courseDetailsViewModel.CreatedDate,
                ImageUrl = courseDetailsViewModel.ImageUrl,
                Videos = courseDetailsViewModel.videos,

            };

            return cousre;
        }

        public static List<Course> CourseDetailsViewModelToCourse(List<CourseDetailsViewModel> courseDetailsViewModelList)
        {
            var cousreList = new List<Course>();
            foreach (var courseDetailsViewModel in courseDetailsViewModelList)
            {
                int decodedId = BitConverter.ToInt32(Convert.FromBase64String(courseDetailsViewModel.Id));
                var cousre = new Course
                {
                    Id = decodedId,
                    TeacherProfileId = courseDetailsViewModel.TeacherProfileId,
                    Title = courseDetailsViewModel.Title,
                    Description = courseDetailsViewModel.Description,
                    Price = courseDetailsViewModel.Price,
                    IsDeleted = courseDetailsViewModel.IsDeleted,
                    IsActive = courseDetailsViewModel.IsActive,
                    CreatedDate = courseDetailsViewModel.CreatedDate,
                    ImageUrl = courseDetailsViewModel.ImageUrl,
                    Videos = courseDetailsViewModel.videos,
                };
                cousreList.Add(cousre);
            }

            return cousreList;
        }
    }
}
