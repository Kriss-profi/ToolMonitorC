using ToolMonitorC.Repositories;
using ToolMonitorC.Entities;
using ToolMonitorC.Entities.Extensions;
using ToolMonitorC.Data;
using ToolMonitorC.Repositories.Extensions;

//var itemAdded = new ItemAdded<Employee>(EmployeeAdded);

var employeeRepository = new SqlRepository<Employee>(new ToolMonitorDbContext(), EmployeeAdded);
employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
}

AddEmployees(employeeRepository);
GetElementById(employeeRepository);
WriteAllToConsole(employeeRepository);


static void EmployeeAdded(Employee item)
{
    //var employee = item as Employee;
    Console.WriteLine($"{item.FirstName} added.");
}

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
    var employees = new[]
    {
        new Employee { FirstName = "Krzysiek" },
        new Employee { FirstName = "Kuba"},
        new Employee { FirstName = "Kacper"},
        new Employee { FirstName = "Renata"}
    };
    employeeRepository.AddBatch(employees);
    
    //AddBatch(employeeRepository, employees);

    //employeeRepository.Add(new Employee { FirstName = "Krzysiek" });
    //employeeRepository.Add(new Employee { FirstName = "Kuba" });
    //employeeRepository.Add(new Employee { FirstName = "Kacper" });
    //employeeRepository.Add(new Employee { FirstName = "Renata" });
    //employeeRepository.Save();
}

//static void AddBatch<T>(IRepository<T> repository, T[] items) where T : class, IEntity
//{
//    foreach (var item in items)
//    {
//        repository.Add(item);
//    }
//    repository.Save();
//}