using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourse_Project.Models;

namespace Infrastructure.Identity
{
    public class OnlineCourse_DbContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineCourse_DbContext(DbContextOptions<OnlineCourse_DbContext> options) : base(options) { }

        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderCourse> OrderCourses { get; set; }

        public DbSet<TeacherProfile> Teachers { get; set; }
        public DbSet<StudentProfile> Students { get; set; }

        public DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Course>()
                .HasMany(c => c.Videos)
                .WithOne(v => v.Course)
                .HasForeignKey(v => v.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderCourse>()
                .HasKey(oc => new { oc.OrderId, oc.CourseId });

            modelBuilder.Entity<OrderCourse>()
                .HasOne(oc => oc.Course)
                .WithMany(c => c.OrderCourses)
                .HasForeignKey(oc => oc.CourseId);
            modelBuilder.Entity<OrderCourse>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderCourses)
                .HasForeignKey(oc => oc.OrderId);

            modelBuilder.Entity<TeacherProfile>()
                .HasOne(t => t.User)
                .WithOne(u => u.TeacherProfile)
                .HasForeignKey<TeacherProfile>(p => p.UserId);

            modelBuilder.Entity<StudentProfile>()
                .HasOne(s=>s.User)
                .WithOne(u=>u.StudentProfile)
                .HasForeignKey<StudentProfile>(s => s.UserId);
        }
    }
}
