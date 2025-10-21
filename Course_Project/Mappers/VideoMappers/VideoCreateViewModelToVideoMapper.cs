using OnlineCourse.Web_Project.ViewModels.VideoViewModels;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers.VideoMappers
{
    public class VideoCreateViewModelToVideoMapper
    {
        public static VideoCreateViewModel VideoToVideoCreateViewModel(Video video)
        {
            var encodedCourseId = Convert.ToBase64String(BitConverter.GetBytes(video.CourseId));
            var videoCreateViewModel = new VideoCreateViewModel
            {
                Title = video.Title,
                CourseId = encodedCourseId,
                Description = video.Description,
                Url = video.Url,
            };

            return videoCreateViewModel;
        }

        public static List<VideoCreateViewModel> VideoToVideoCreateViewModel(List<Video> videoList)
        {
            var videoCreateViewModelList = new List<VideoCreateViewModel>();
            foreach (var video in videoList)
            {
                var encodedId = Convert.ToBase64String(BitConverter.GetBytes(video.Id));
                var encodedCourseId = Convert.ToBase64String(BitConverter.GetBytes(video.CourseId));

                var videoCreateViewModel = new VideoCreateViewModel
                {
                    Title = video.Title,
                    CourseId = encodedCourseId,
                    Description = video.Description,
                    Url = video.Url,
                };
                videoCreateViewModelList.Add(videoCreateViewModel);
            }

            return videoCreateViewModelList;
        }
        public static Video VideoCreateViewModelToVideo(VideoCreateViewModel videoCreateViewModel)
        {
            var decodedCourseId = BitConverter.ToInt32(Convert.FromBase64String(videoCreateViewModel.CourseId));
            var video = new Video
            {
                Title = videoCreateViewModel.Title,
                CourseId = decodedCourseId,
                Description = videoCreateViewModel.Description,
                Url = videoCreateViewModel.Url,

            };

            return video;
        }

        public static List<Video> VideoCreateViewModelToVideo(List<VideoCreateViewModel> videoCreateViewModelList)
        {
            var videoList = new List<Video>();
            foreach (var videoCreateViewModel in videoCreateViewModelList)
            {
                var decodedCourseId = BitConverter.ToInt32(Convert.FromBase64String(videoCreateViewModel.CourseId));
                var video = new Video
                {
                    Title = videoCreateViewModel.Title,
                    CourseId = decodedCourseId,
                    Description = videoCreateViewModel.Description,
                    Url = videoCreateViewModel.Url,
                };
                videoList.Add(video);
            }

            return videoList;
        }
    }
}
