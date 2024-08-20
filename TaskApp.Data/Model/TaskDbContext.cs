using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TaskApp.Data.Model
{
    public class TaskDbContext : DbContext
    {
        public string ConnectionString;

        public TaskDbContext()
        {
        }
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
