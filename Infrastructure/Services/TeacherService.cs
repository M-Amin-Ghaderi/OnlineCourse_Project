using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace OnlineCourse.Web_Project.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<TeacherProfile> GetTeacherByUserIdAsync(string userId)
        {
            return await teacherRepository.GetTeacherByUserIdAsync(userId);
        }

        public async Task<int> GetTeacherStudentCountAsync(string userId)
        {
            return await teacherRepository.GetTeacherStudentCountAsync(userId);
        }
        public async Task<int> GetTeacherCourseCountAsync(string userId)
        {
            return await teacherRepository.GetTeacherCourseCountAsync(userId);
        }

        public async Task<decimal> GetTeacherTotalIncomeAsync(string userId)
        {
            return await teacherRepository.GetTeacherTotalIncomeAsync(userId);
        }

        public async Task<IEnumerable<TeacherProfile>> GetAllAsync()
        {
            return await teacherRepository.GetAllAsync();
        }

        public async Task Add(TeacherProfile teacher)
        {
            await teacherRepository.Add(teacher);
        }

        public async Task SaveChangesAsync()
        {
            await teacherRepository.SaveChangesAsync();
        }
    }
}
