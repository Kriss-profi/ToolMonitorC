using Microsoft.EntityFrameworkCore;
using ToolMonitorC.Entities;

namespace ToolMonitorC.Data
{
    internal class ToolMonitorDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Tool> Tools => Set<Tool>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
