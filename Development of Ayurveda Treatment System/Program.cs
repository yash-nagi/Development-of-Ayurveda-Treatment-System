using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Repository;
using Development_of_Ayurveda_Treatment_System.Services;
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

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Dependency injection for database server string
            //var connectionString = Environment.GetEnvironmentVariable("AYURGROW_DB_CONNECTION");

            builder.Services.AddDbContext<AyurgrowDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories dependencies injection.
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<ILogin, LoginRepository>();
            builder.Services.AddScoped<IMedicine, MedicineRepository>();
            builder.Services.AddScoped<IVendor, VendorRepository>();
            builder.Services.AddScoped<ICourses, CoursesRepository>();
            builder.Services.AddScoped<IEbooks, EbooksRepository>();
            builder.Services.AddScoped<IDoctor, DoctorRepository>();

            // Add Services dependencies injection.
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<LoginSevice>();
            builder.Services.AddScoped<MedicineService>();
            builder.Services.AddScoped<VendorService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<EbookService>();
            builder.Services.AddScoped<DoctorsService>();

            builder.Services.AddHttpContextAccessor();
            
            builder.Services.AddAuthentication("Cookies")
            .AddCookie("Cookies", options =>
            {
                options.LoginPath = "/Login/Login";   // Redirect to login if not authenticated
                options.ExpireTimeSpan = TimeSpan.FromDays(30); // Default expiry
                options.SlidingExpiration = true;
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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