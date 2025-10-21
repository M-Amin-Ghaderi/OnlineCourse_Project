using Domain.Interfaces;
using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await courseRepository.GetAllAsync();
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await courseRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Course course)
        {
            await courseRepository.AddAsync(course);
        }
        public void Update(Course course)
        {
            courseRepository.Update(course);
        }
        public async Task SaveChangesAsync()
        {
            await courseRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await courseRepository.DeleteAsync(id);
        }
    }
}
