using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAudio.Wave;
using OnlineCourse.Web_Project.Mappers.VideoMappers;
using OnlineCourse.Web_Project.ViewModels.VideoViewModels;
using OnlineCourse_Project.Models;
namespace OnlineCourse.Web_Project.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoService videoService;
        public VideosController(IVideoService videoService)
        {
            this.videoService = videoService;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoViewModel videoViewModel, IFormFile? videoFile)
        {
            if (ModelState.IsValid)
            {

                if (videoFile != null && videoFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(videoFile.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await videoFile.CopyToAsync(fileSteam);
                    }

                    videoViewModel.Url = "/uploads/" + fileName;

                }
                var video = VideoViewModelToVideoMapper.VideoViewModelToVideo(videoViewModel);
                await videoService.AddAsync(video);
                await videoService.SaveChangesAsync();

                var videos = await videoService.GetAllByCourseIdAsync(video.Id);
                return RedirectToAction("Details", "Courses", new { id = video.CourseId });
            }
            return BadRequest(ModelState);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var video = await videoService.GetById(id.Value);
            if (video == null) return NotFound();

            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Video video, IFormFile? videoFile)
        {
            if (id != video.Id) NotFound();

            if (ModelState.IsValid)
            {
                if (videoFile != null && videoFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(videoFile.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await videoFile.CopyToAsync(fileSteam);
                    }

                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", video.Url.TrimStart('/')));

                    video.Url = "/uploads/" + fileName;
                }

                try
                {
                    videoService.Update(video);
                    await videoService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (videoService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Courses", new { id = video.CourseId });
            }
            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var video = await videoService.GetById(id);
            if (video == null) return NotFound();
            int courseId = video.CourseId;
            await videoService.DeleteAsync(courseId);
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", video.Url.TrimStart('/')));
            await videoService.SaveChangesAsync();
            return RedirectToAction("Details", "Courses", new { id = courseId });
        }
    }
}
