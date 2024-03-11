using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Day06.Services;
using System.Configuration;
using Day06.Models;
namespace Day06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(a=>
            {
                a.Cookie.Name = "xyz";
            });
            builder.Services.AddTransient<IDepartmentRepo,DepartmentRepo>() ;
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(a=>
              {
                 // a.LoginPath = "/home/index";
              });
              

            builder.Services.AddDbContext<ITIDBContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("Con1"));
            });   // adding connection string 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            //1-
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
