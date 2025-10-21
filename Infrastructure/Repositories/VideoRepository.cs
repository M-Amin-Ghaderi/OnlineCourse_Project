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
    public class VideoRepository : IVideoRepository
    {
        private readonly OnlineCourse_DbContext context;

        public VideoRepository(OnlineCourse_DbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Video video)
        {
            await context.Videos.AddAsync(video);
        }

        public async Task DeleteAsync(int videoId)
        {
            var video = await GetById(videoId);
            video.IsDeleted = true;
        }

        public async Task<List<Video>> GetAllByCourseIdAsync(int courseId)
        {
            return await context.Videos.Where(v => v.CourseId == courseId).ToListAsync();
        }

        public async Task<Video> GetById(int id)
        {
            return await context.Videos.Include(v => v.Course).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Video video)
        {
            context.Videos.Update(video);
        }
    }
}
