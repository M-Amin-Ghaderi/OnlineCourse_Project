using OnlineCourse.Web_Project.ViewModels.Course;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers.CourseMappers
{
    public class CourseEditViewModelMapper
    {
        public static CourseEditViewModel CourseToCourseEditViewModel(Course course)
        {
            string encodedId = Convert.ToBase64String(BitConverter.GetBytes(course.Id));
            var courseEditViewModel = new CourseEditViewModel
            {
                Id = encodedId,
                TeacherProfileId = course.TeacherProfileId,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ImageUrl = course.ImageUrl,
            };

            return courseEditViewModel;
        }

        public static List<CourseEditViewModel> CourseToCourseEditViewModel(List<Course> courseList)
        {
            var courseEditViewModelList = new List<CourseEditViewModel>();
            foreach (var course in courseList)
            {
                string encodedId = Convert.ToBase64String(BitConverter.GetBytes(course.Id));
                var courseEditViewModel = new CourseEditViewModel
                {
                    Id = encodedId,
                    TeacherProfileId = course.TeacherProfileId,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    ImageUrl = course.ImageUrl,

                };
                courseEditViewModelList.Add(courseEditViewModel);
            }

            return courseEditViewModelList;
        }

        public static Course CourseEditViewModelToCourse(CourseEditViewModel courseEditViewModel)
        {
            int decodedId = BitConverter.ToInt32(Convert.FromBase64String(courseEditViewModel.Id));
            var cousre = new Course
            {
                Id = decodedId,
                TeacherProfileId = courseEditViewModel.TeacherProfileId,
                Title = courseEditViewModel.Title,
                Description = courseEditViewModel.Description,
                Price = courseEditViewModel.Price,
                ImageUrl = courseEditViewModel.ImageUrl,

            };

            return cousre;
        }

        public static List<Course> CourseEditViewModelToCourse(List<CourseEditViewModel> courseEditViewModelList)
        {
            var cousreList = new List<Course>();
            foreach (var courseEditViewModel in courseEditViewModelList)
            {
                int decodedId = BitConverter.ToInt32(Convert.FromBase64String(courseEditViewModel.Id));
                var cousre = new Course
                {
                    Id = decodedId,
                    TeacherProfileId = courseEditViewModel.TeacherProfileId,
                    Title = courseEditViewModel.Title,
                    Description = courseEditViewModel.Description,
                    Price = courseEditViewModel.Price,
                    ImageUrl = courseEditViewModel.ImageUrl,
                };
                cousreList.Add(cousre);
            }

            return cousreList;
        }
    }
}
