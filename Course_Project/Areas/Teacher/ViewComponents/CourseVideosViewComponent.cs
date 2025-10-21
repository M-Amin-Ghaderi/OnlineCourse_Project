using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Web_Project.Mappers.VideoMappers;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Areas.Teacher.ViewComponents
{
    public class CourseVideosViewComponent : ViewComponent
    {
        private readonly IVideoService videoService;

        public CourseVideosViewComponent(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string courseId)
        {
            int decodedId = BitConverter.ToInt32(Convert.FromBase64String(courseId));
            var videos = await videoService.GetAllByCourseIdAsync(decodedId);
            var videosViewModelList = VideoViewModelToVideoMapper.VideoToVideoViewModel(videos);
            return View("CourseVideos", videosViewModelList);
        }
    }
}
