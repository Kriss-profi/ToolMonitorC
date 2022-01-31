using ToolMonitorC.Repositories;
using ToolMonitorC.Entities;
using ToolMonitorC.Data;

var employeeRepository = new SqlRepository<Employee>(new ToolMonitorDbContext());
AddEmployees(employeeRepository);
GetElementById(employeeRepository);
WriteAllToConsole(employeeRepository);

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var employee in items)
    {
        Console.WriteLine(employee);
    }
}

static void GetElementById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine(employee.ToString());
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Krzysiek" });
    employeeRepository.Add(new Employee { FirstName = "Kuba" });
    employeeRepository.Add(new Employee { FirstName = "Kacper" });
    employeeRepository.Add(new Employee { FirstName = "Renata" });
    employeeRepository.Save();
}
