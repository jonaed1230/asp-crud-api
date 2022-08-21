using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MediaAPIDbContext : DbContext
    {
        public MediaAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Media> Medias { get; set; }
    }
}
