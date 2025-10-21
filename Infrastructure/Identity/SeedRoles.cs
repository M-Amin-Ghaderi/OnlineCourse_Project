
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using OnlineCourse_Project.Models;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class SeedRoles
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, OnlineCourse_DbContext context)
        {
            string[] roleNames = { "Admin", "Student", "Teacher" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminEmail = "admin@site.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(user, "@Admin1234@");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            var teacherEmail = "teacher@site.com";
            var teacherUser = await userManager.FindByEmailAsync(teacherEmail);
            if (teacherUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "teacher",
                    Email = teacherEmail,
                    EmailConfirmed = true,
                };
                var result = await userManager.CreateAsync(user, "@Teacher1234@");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Teacher");
                    var teacher = new TeacherProfile
                    {
                        UserId = user.Id,
                    };
                    context.Teachers.Add(teacher);
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
