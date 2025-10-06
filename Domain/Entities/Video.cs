namespace OnlineCourse_Project.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty ;

        public TimeSpan Duration { get; set; }
        public Course? Course { get; set; }
    }
}
