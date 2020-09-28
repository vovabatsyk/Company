using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain;
using Company.Domain.Repositories.Abstract;
using Company.Domain.Repositories.EntityFramework;
using Company.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Company
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            // подключаем Config з appsettings.json
            Configuration.Bind("Project", new Config());

            // подключаем сервисы
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            // подключаем контекст БД
            services.AddDbContext<AppDbCondext>(x => x.UseSqlServer(Config.ConnectionString));

            // настраеваим identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbCondext>().AddDefaultTokenProviders();

            // настраеваим authorization cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "account/accessdenied";
                options.SlidingExpiration = true;
            });

            // настраиваем политику Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin");});
            });

            // подключаем MVC
            services.AddControllersWithViews(x =>
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            // подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // подключаем routes(endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=HomeController}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=HomeController}/{action=Index}/{id?}");
            });
        }
    }
}

// 32.54
