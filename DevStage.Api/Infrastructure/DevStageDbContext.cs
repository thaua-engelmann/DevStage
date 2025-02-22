using DevStage.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStage.Api.Infrastructure
{
    public class DevStageDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\engel\\OneDrive\\Documents\\DevStageDB.db");
        }

    }
}
