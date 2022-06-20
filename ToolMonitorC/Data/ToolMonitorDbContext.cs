using Microsoft.EntityFrameworkCore;
using ToolMonitorC.Data.Entities;

namespace ToolMonitorC.Data
{
    public class ToolMonitorDbContext : DbContext
    {
        public ToolMonitorDbContext(DbContextOptions<ToolMonitorDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }





        //public DbSet<Employee> Employees => Set<Employee>();
        
        ////
        ////public DbSet<User> Users => Set<User>();
        ////public DbSet<Tool> Tools => Set<Tool>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ToolMonitorCStorage;Integrated Security=True");
        //    //optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        //    //var optionBuilder = new DbContextOptionsBuilder<ToolMonitorDbContext>();
        //    //optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ToolMonitorCStorage;Integrated Security=True");
        //    //return new ToolMonitorDbContext(optionBuilder.Options);
        //}
    }
}
