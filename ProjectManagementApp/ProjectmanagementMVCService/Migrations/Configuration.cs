using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectmanagementMVCService.Models;

namespace ProjectmanagementMVCService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectmanagementMVCService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectmanagementMVCService.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            AddRoles(context);
            AddUsers(context);
        }

        private void AddUsers(ApplicationDbContext context)
        {
            string email = "nora.alam07@gmail.com";
            ApplicationUser applicationUser = context.Users.FirstOrDefault(x => x.Email == email);
            if (applicationUser == null)
            {
                var userId = Guid.NewGuid().ToString();
                IdentityRole identityRole = context.Roles.First(x => x.Name == "ItAdmin");
                IdentityUserRole userRole = new IdentityUserRole()
                {
                    UserId = userId,
                    RoleId = identityRole.Id
                    
                };
                PasswordHasher hasher= new PasswordHasher();
                string pass = hasher.HashPassword("123456");

                applicationUser = new ApplicationUser()
                {
                    Email = email,
                    UserName = email,
                    Id = userId,
                    Roles = { userRole },
                    PasswordHash = pass
                };
                context.Users.Add(applicationUser);
                context.SaveChanges();

            }
        }

        private void AddRoles(ApplicationDbContext context)
        {
            List<string> roles = new List<string>() {"ItAdmin", "ProjectManager", "User"};

            foreach (string role in roles)
            {
                IdentityRole identityRole = context.Roles.FirstOrDefault(x => x.Name == role);
                if (identityRole == null)
                {
                    identityRole = new IdentityRole(role);
                    context.Roles.Add(identityRole);
                }
            }
            context.SaveChanges();
        }
    }
}
