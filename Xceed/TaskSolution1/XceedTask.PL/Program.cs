using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using XceedTask.BLL.Interfaces;
using XceedTask.BLL;
using XceedTask.DAL.Contexts;
using XceedTask.DAL.Models;

namespace XceedTask.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // This method gets called by the runtime. Use this method to add services to the container.
            #region ConfigureServices

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUintOfWork, UintOfWork>();

            builder.Services.AddIdentity<User, IdentityRole>()
              .AddEntityFrameworkStores<TaskDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/SignIn";
                options.AccessDeniedPath = "/Product/Index";
            });

            #endregion
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            #region Configure

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}