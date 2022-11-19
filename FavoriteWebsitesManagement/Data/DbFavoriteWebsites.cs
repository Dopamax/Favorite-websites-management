using FavoriteWebsitesManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoriteWebsitesManagement.Data
{
    public class DbFavoriteWebsites : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Website> Websites { get; set; }

        public DbFavoriteWebsites(DbContextOptions options) : base(options)
        {
        }
    }
}
