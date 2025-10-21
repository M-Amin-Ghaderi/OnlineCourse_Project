using OnlineCourse_Project.Models;

namespace Domain.Interfaces
{
    public interface IVideoRepository
    {
        Task<List<Video>> GetAllByCourseIdAsync(int courseId);

        Task<Video> GetById(int id);

        Task AddAsync(Video video);

        void Update(Video video);

        Task DeleteAsync(int videoId);

        Task SaveChangesAsync();


    }
}
