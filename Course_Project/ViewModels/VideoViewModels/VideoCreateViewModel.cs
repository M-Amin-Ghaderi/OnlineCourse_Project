﻿namespace OnlineCourse.Web_Project.ViewModels.VideoViewModels
{
    public class VideoCreateViewModel
    {
        public string CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IFormFile? VideoFile { get; set; }
    }
}
