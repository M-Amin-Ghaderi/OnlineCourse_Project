namespace OnlineCourse.Web_Project.ViewModels.VideoViewModels
{
    public class VideoViewModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
