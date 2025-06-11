using Microsoft.EntityFrameworkCore;
using Resturants.Models;

namespace Resturants.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
