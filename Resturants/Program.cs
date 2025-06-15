using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.Models;

namespace Resturants
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }
               );

            var app = builder.Build();



         
            app.UseStaticFiles();

          
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
