using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public readonly OnlineCourse_DbContext context;

        public TeacherRepository(OnlineCourse_DbContext context)
        {
            this.context = context;
        }

        public async Task<TeacherProfile> GetTeacherByUserIdAsync(string userId)
        {
            return await context.Teachers.Include(t => t.Courses).ThenInclude(c => c.OrderCourses).FirstOrDefaultAsync(t => t.UserId == userId);
        }
        public async Task<IEnumerable<TeacherProfile>> GetAllAsync()
        {
            return await context.Teachers.Include(t => t.Courses).ToListAsync();
        }
        public async Task Add(TeacherProfile teacher)
        {
            await context.Teachers.AddAsync(teacher);
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<int> GetTeacherCourseCountAsync(string userId)
        {
            var teacher = await GetTeacherByUserIdAsync(userId);
            if (teacher is null)
            {
                return 0;
            }
            var courseCount = teacher.Courses.Count();
            return courseCount;
        }

        public async Task<int> GetTeacherStudentCountAsync(string userId)
        {
            var teacher = await GetTeacherByUserIdAsync(userId);
            if (teacher == null)
                return 0;

            var studentCount = teacher.Courses
                .SelectMany(c => c.OrderCourses)
                .Select(oc => oc.Order.UserId).Distinct().Count();

            return studentCount;
        }

        public async Task<decimal> GetTeacherTotalIncomeAsync(string userId)
        {
            var teacher = await GetTeacherByUserIdAsync(userId);
            if (teacher is null)
            {
                return 0;
            }
            return await context.OrderCourses.Where(oc => oc.Course.Teacher.UserId == teacher.UserId).SumAsync(oc => oc.Price);
        }
    }
}
