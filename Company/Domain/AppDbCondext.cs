using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Company.Domain
{
    public class AppDbCondext:IdentityDbContext<IdentityUser>
    {
        public AppDbCondext(DbContextOptions<AppDbCondext> options) : base(options) {}

        public  DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems{ get; set; }

  
        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            base.OnModelCreating(modeBuilder);

            modeBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "8af10569-b018-4fe7-7d6a14c70b74",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modeBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "8af10569-b018-4fe7-2f6a43c70c75",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "webproger.ua@gmail.com",
                NormalizedEmail = "WEBPROGER.UA@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"superpassword"),
                SecurityStamp = string.Empty
            });

            modeBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "8af10569-b018-4fe7-7d6a14c70b74",
                UserId = "8af10569-b018-4fe7-2f6a43c70c75"
            });

            modeBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4a2b661caa2b4cc1b8c84c8ad964baa4"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modeBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("178c8f76d95d4b07a1fadea7b9f7d661"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modeBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("7f0bfa7017674676b1f5dd4b30f8e3a8"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

        }
    }
}
