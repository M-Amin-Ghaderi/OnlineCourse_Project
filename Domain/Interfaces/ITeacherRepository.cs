using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeacherRepository
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
