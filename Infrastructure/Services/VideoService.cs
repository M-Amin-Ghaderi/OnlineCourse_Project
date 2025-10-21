using Domain.Interfaces;
using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async Task AddAsync(Video video)
        {
           await videoRepository.AddAsync(video);
        }

        public async Task DeleteAsync(int videoId)
        {
           await videoRepository.DeleteAsync(videoId);
        }

        public async Task<List<Video>> GetAllByCourseIdAsync(int courseId)
        {
           return await videoRepository.GetAllByCourseIdAsync(courseId);
        }

        public async Task<Video> GetById(int id)
        {
            return await videoRepository.GetById(id);
        }

        public async Task SaveChangesAsync()
        {
           await videoRepository.SaveChangesAsync();
        }

        public void Update(Video video)
        {
            videoRepository.Update(video);
        }
    }
}
