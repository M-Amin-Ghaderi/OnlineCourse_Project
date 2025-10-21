using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineCourse.Web_Project.ViewModels.VideoViewModels;
using OnlineCourse_Project.Models;

namespace OnlineCourse.Web_Project.Mappers.VideoMappers
{
    public class VideoViewModelToVideoMapper
    {
        public static VideoViewModel VideoToVideoViewModel(Video video)
        {
            var encodedId = Convert.ToBase64String(BitConverter.GetBytes(video.Id));
            var encodedCourseId = Convert.ToBase64String(BitConverter.GetBytes(video.CourseId));
            var videoViewModel = new VideoViewModel
            {
                Id = encodedId,
                Title = video.Title,
                CourseId = encodedCourseId,
                Description = video.Description,
                Url = video.Url,
            };

            return videoViewModel;
        }

        public static List<VideoViewModel> VideoToVideoViewModel(List<Video> videoList)
        {
            var videoViewModelList = new List<VideoViewModel>();
            foreach (var video in videoList)
            {
                var encodedId = Convert.ToBase64String(BitConverter.GetBytes(video.Id));
                var encodedCourseId = Convert.ToBase64String(BitConverter.GetBytes(video.CourseId));

                var videoViewModel = new VideoViewModel
                {
                    Id = encodedId,
                    Title = video.Title,
                    CourseId = encodedCourseId,
                    Description = video.Description,
                    Url = video.Url,
                };
                videoViewModelList.Add(videoViewModel);
            }

            return videoViewModelList;
        }
        public static Video VideoViewModelToVideo(VideoViewModel videoViewModel)
        {
            var decodedId = BitConverter.ToInt32(Convert.FromBase64String(videoViewModel.Id));
            var decodedCourseId = BitConverter.ToInt32(Convert.FromBase64String(videoViewModel.CourseId));
            var video = new Video
            {
                Id = decodedId,
                Title = videoViewModel.Title,
                CourseId = decodedCourseId,
                Description = videoViewModel.Description,
                Url = videoViewModel.Url,

            };

            return video;
        }

        public static List<Video> VideoViewModelToVideo(List<VideoViewModel> videoViewModelList)
        {
            var videoList = new List<Video>();
            foreach (var videoViewModel in videoViewModelList)
            {
                var decodedId = BitConverter.ToInt32(Convert.FromBase64String(videoViewModel.Id));
                var decodedCourseId = BitConverter.ToInt32(Convert.FromBase64String(videoViewModel.CourseId));
                var video = new Video
                {
                    Id= decodedId,
                    Title = videoViewModel.Title,
                    CourseId = decodedCourseId,
                    Description = videoViewModel.Description,
                    Url = videoViewModel.Url,
                };
                videoList.Add(video);
            }

            return videoList;
        }
    }
}
