using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturants.Models;

namespace Resturants.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ChefMeal> ChefMeals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<SosialMedia> SosialMedias { get; set; }





    }
}
