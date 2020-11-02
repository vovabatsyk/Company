using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetCompany.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotNetCompany.Domain
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "65eee928-f6f0-4b39-8cba-8b92d5e9f2c9",
                Name = "admin",
                NormalizedName = "ADMIN",
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c3d9e19b-78f1-44b2-989f-f4b87018bb0a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "vovabatsyk@gmail.com",
                NormalizedEmail = "VOVABATSYK@GMAIL>COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "65eee928-f6f0-4b39-8cba-8b92d5e9f2c9",
                UserId = "c3d9e19b-78f1-44b2-989f-f4b87018bb0a"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("bb175a44-4547-4ff8-8926-dc8b73a86f96"),
                CodeWord = "PageIndex",
                Title = "Home"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {

                Id = new Guid("eb0dfd17-29c7-4754-8d4b-4332beea4d95"),
                CodeWord = "PageServices",
                Title = "Our Services"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {

                Id = new Guid("dbac37c5-0c45-44fb-89e3-9aa20174e7d1"),
                CodeWord = "PageContacts",
                Title = "Our Contacts"
            });

        }

    }
}
