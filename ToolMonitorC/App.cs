using ToolMonitorC.Data;
using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;

namespace ToolMonitorC
{
    public class App : IApp
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Tool> toolRepository;
        private readonly ToolMonitorDbContext toolMonitorDbContext;

        public App(IRepository<Employee> employeeRepository, IRepository<Tool> toolRepository, ToolMonitorDbContext toolMonitorDbContext)
        {
            this.employeeRepository = employeeRepository;
            this.toolRepository = toolRepository;
            this.toolMonitorDbContext = toolMonitorDbContext;
            toolMonitorDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            Console.WriteLine("RUN");

            //ReadAllEmployeesFromSql();

        }

        private void ReadAllEmployeesFromSql()
        {
            var ToolsFromDb = toolMonitorDbContext.Employees.ToList();
            foreach (var tool in ToolsFromDb)
            {
                Console.WriteLine(tool);
            }
        }

        private void ReadAllToolsFromSql()
        {
            var ToolsFromDb = toolMonitorDbContext.Tools.ToList();
            foreach (var tool in ToolsFromDb)
            {
                Console.WriteLine(tool);
            }
        }
    }
}
