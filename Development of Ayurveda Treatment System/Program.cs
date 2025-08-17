using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Repository;
using Development_of_Ayurveda_Treatment_System.Service;
using Microsoft.EntityFrameworkCore;

namespace Development_of_Ayurveda_Treatment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Dependency injection for database server string
            //var connectionString = Environment.GetEnvironmentVariable("AYURGROW_DB_CONNECTION");

            builder.Services.AddDbContext<AyurgrowDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories dependencies injection.
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<ILogin, LoginRepository>();

            // Add Services dependencies injection.
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<LoginSevice>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}