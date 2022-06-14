using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;

namespace ToolMonitorC
{
    public class Temp : ITemp
    {
        private readonly IRepository<Employee> employeeRepository;

        public Temp(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void RunTemp()
        {
            Console.WriteLine("I'm here in TempRun() method");

            //GetAllEmployee(employeeRepository);
            List<Employee> allEmployees = employeeRepository.GetAll().ToList();
            int i = 1;
            foreach (Employee employee in allEmployees)
            {
                Console.WriteLine($"\t{i}. {employee.ToString()}");
                i++;
            }
            Console.ReadKey();
            
            Console.WriteLine(allEmployees[2]);

            allEmployees.Remove(allEmployees[1]);
            i = 1;
            foreach (Employee employee in allEmployees)
            {
                Console.WriteLine($"\t{i}. {employee.ToString()}");
                i++;
            }
            Console.ReadKey();

            Console.WriteLine(allEmployees[2]);
        }
    }
}
