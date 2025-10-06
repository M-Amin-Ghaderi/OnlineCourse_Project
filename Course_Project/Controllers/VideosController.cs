using NAudio.Wave;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;
using System.IO;
using Infrastructure.Identity;
namespace OnlineCourse.Web_Project.Controllers
{
    public class VideosController : Controller
    {
        private readonly OnlineCourse_DbContext context;


        public VideosController(OnlineCourse_DbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Video video, IFormFile? videoFile)
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

                    video.Url = "/uploads/" + fileName;

                }

                context.Add(video);
                await context.SaveChangesAsync();

                var videos = await context.Videos.Where(v => v.CourseId == video.CourseId).ToListAsync();
                return RedirectToAction("Details", "Courses", new { id = video.CourseId });
            }
            return BadRequest(ModelState);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var video = await context.Videos.FindAsync(id);
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
                    context.Update(video);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!context.Videos.Any(v => v.Id == id))
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
            var video = await context.Videos.FindAsync(id);
            if (video == null) return NotFound();
            int courseId = video.CourseId;
            context.Videos.Remove(video);
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", video.Url.TrimStart('/')));
            await context.SaveChangesAsync();
            return RedirectToAction("Details", "Courses", new { id = courseId });
        }
    }
}
