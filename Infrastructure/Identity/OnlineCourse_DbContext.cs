using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourse_Project.Models;

namespace Infrastructure.Identity
{
    public class OnlineCourse_DbContext : IdentityDbContext<User>
    {
        public OnlineCourse_DbContext(DbContextOptions<OnlineCourse_DbContext> options) : base(options) { }

        public DbSet<User> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Course>()
                .HasMany(c => c.Videos)
                .WithOne(v => v.Course)
                .HasForeignKey(v => v.CourseId);

            modelBuilder.Entity<User>()
                .HasMany(u=>u.Orders)
                .WithOne(o=>o.AppUser)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Course>()
                .HasMany<Order>()
                .WithOne(o => o.Course)
                .HasForeignKey(o => o.CourseId);
        }
    }
}
