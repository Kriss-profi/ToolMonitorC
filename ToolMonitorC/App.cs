using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;

namespace ToolMonitorC
{
    public class App : IApp
    {
        private readonly IRepository<Employee> employeeRepository;

        public App(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Run()
        {
            Console.WriteLine("RUN");

        }
    }
}
