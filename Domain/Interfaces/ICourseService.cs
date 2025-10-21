using OnlineCourse_Project.Models;

namespace Domain.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course course);
        void Update(Course course);
        Task SaveChangesAsync();
        Task DeleteAsync(int id);
    }
}
