using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherProfile> GetTeacherByUserIdAsync(string userId);
        Task<IEnumerable<TeacherProfile>> GetAllAsync();

        Task<int> GetTeacherCourseCountAsync(string userId);
        Task<int> GetTeacherStudentCountAsync(string userId);
        Task<decimal> GetTeacherTotalIncomeAsync(string userId);

        Task Add(TeacherProfile teacher);
        Task SaveChangesAsync();
    }
}
