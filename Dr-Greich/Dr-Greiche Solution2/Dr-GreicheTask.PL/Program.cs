using Demo.PL.MappingProfile;
using Dr_GreicheTask.PL.Data;
using Dr_GreicheTask.PL.Models;
using Microsoft.EntityFrameworkCore;

namespace Dr_GreicheTask.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddDbContext<InsuranceDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(M => M.AddProfile(new InsurancePaperProfile()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=InsurancePaper}/{action=DashBoardView}/{id?}");

            app.Run();
        }
    }
}