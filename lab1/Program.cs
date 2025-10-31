using lab1.DAL;
using lab1.Models;
using lab1.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEntityRepo<Student>,StudentRepo>();
            builder.Services.AddScoped < IEntityRepo < Departments >, DEpartmentRepo > ();
            builder.Services.AddScoped < DepartmentCourseRepo > ();
            builder.Services.AddDbContext<ITIDbContext>(op=>
            { 
            //2 in Auth
            op.UseSqlServer("Data Source=OSAMA;Initial Catalog=ITI2;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");

            });
            builder.Services.AddDbContext<AuthDbContext>(op =>
            {

                  op.UseSqlServer("Data Source=OSAMA;Initial Catalog=ITI2AuthDb;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");
                //op.UseSqlServer(builder.Configuration.GetConnectionString("con2")); //"Data Source=OSAMA;Initial Catalog=ITI2AuthDb;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");

            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(s =>
            {
                s.Password.RequiredLength = 4;
                s.Password.RequireUppercase= true;
                s.Password.RequireNonAlphanumeric= false;
                }

            ).AddEntityFrameworkStores<AuthDbContext>();


            builder.Services.AddAuthentication("MyCookieAuth").AddCookie
                ("MyCookieAuth", opt =>
                {
                    opt.Cookie.Name = "MyCookieAuth"; //name of cookie
                    opt.LoginPath = "/Account/Login"; //redirect to 
                //    opt.AccessDeniedPath = "/"; //redirekt to 

                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // 1  in Auth

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
