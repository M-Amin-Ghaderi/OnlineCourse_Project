using Domain.Interfaces;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlineCourse_DbContext context;

        public CourseRepository(OnlineCourse_DbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Course course)
        {
            await context.Courses.AddAsync(course);
        }

        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id);
            course.IsDeleted = true;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await context.Courses.Include(c => c.Teacher).Include(c => c.Videos).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Course course)
        {
            context.Courses.Update(course);
        }
    }
}
