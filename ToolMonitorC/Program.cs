using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolMonitorC;
using ToolMonitorC.Data;
using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<ITemp, Temp>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Tool>, ListRepository<Tool>>();
services.AddDbContext<ToolMonitorDbContext>(options => options.UseSqlServer("Data Source=KRISS\\SQLEXPRESS;Initial Catalog=ToolMonitorCStorage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
//var temp = serviceProvider.GetRequiredService<ITemp>();

app.Run();
//temp.RunTemp();

//using ToolMonitorC.Repositories;
//using ToolMonitorC.Entities;
//using ToolMonitorC.Entities.Extensions;
//using ToolMonitorC.Data;
//using ToolMonitorC.Repositories.Extensions;
//using Microsoft.Extensions.Options;

////var itemAdded = new ItemAdded<Employee>(EmployeeAdded);

//var employeeRepository = new SqlRepository<Employee>(new ToolMonitorDbContext(), EmployeeAdded);

//List<Employee> allEmployees;


//const string header = "\n\t      TOOL Monitor   \n";
//void Clear()
//{
//    Console.Clear();
//    Console.WriteLine(header);
//}


//int x = 1;
//while (x != 0)
//{
//    x = Menu();
//    switch (x)
//    {
//        case 0: { break; }
//        case 1: { AddEmployee(employeeRepository); break; }
//        case 2: { ShowAllEmployees(employeeRepository); break; }
//        case 3: { FindEmployee(); break; }
//        case 4: { AddTool(); break; }
//        case 5: { ShowAllTools(); break; }
//        case 6: { FindTool(); break; }
//        case 9: { ReadLogsToConsole(); break; }
//        default: { NotInMenu(); break; }
//    }
//}
//EndApp();

//#region MENU

//    int Menu()
//    {
//        Clear();
//        //Console.WriteLine("Wybierz opcję z Menu: ");
//        Console.WriteLine("\t[1]: Dodaj Pracownika");
//        Console.WriteLine("\t[2]: Pokaż listę Pracowników");
//        Console.WriteLine("\t[3]: Odszukaj Pracownika");
//        Console.WriteLine("\t[4]: Dodaj nowe urządzenie");
//        Console.WriteLine("\t[5]: Pokaż listę urządzeń");
//        Console.WriteLine("\t[6]: Odszukaj urządzenie");
//        Console.WriteLine("\t[0]: Wyjdź z Programu");
//        Console.Write("\t\t ?: ");
//        string line = Console.ReadLine();
//        bool result = int.TryParse(line, out int value);
//        if (result == false) return 100;
//        else return value;
//    }

//    void NotImplementedFunction()
//    {
//        Clear();
//        Console.WriteLine("\tPrzepraszamy ale ta funkcja \n\tjeszcze nie jest dostępna ;(");
//        Console.ReadKey();
//    }


//    void NotInMenu()
//    {
//        Clear();
//        Console.WriteLine("\tTej opcji nie ma w Menu:\n\tSpróbuj ponownie !");
//        Console.ReadKey();
//    }

//    void AddEmployee(IRepository<Employee> employeeRepository)
//    {
//        Clear();
//        Console.WriteLine("    Dodawanie Nowego pwacownika.");
//        Console.Write("\tPodaj Imię: ");
//        string? name = Console.ReadLine();
//        if (name.Length > 0)
//        {
//            employeeRepository.Add(new Employee { FirstName = name });
//            employeeRepository.Save();
//            Console.WriteLine($"Dodano pracownika: {name}");
//            Console.ReadKey();
//        }
//    }
//    void ShowAllEmployees(IRepository<Employee> employeeRepository)
//    {
//        Clear();
//        //List<Employee> employees = employeeRepository.GetAll().ToList();
//        GetAllEmployee(employeeRepository);
//        foreach (Employee employee in allEmployees)
//            Console.WriteLine($"\t{employee.ToString()}");
//        Console.ReadKey();
//    }

//    void FindEmployee()
//    {
//        int idE;
//        Clear();
//        Console.WriteLine("   Możesz szukać po ID lub Imieniu.\n \tWprowadź jedno z nich: ");
//        Console.Write("\t");
//        string line = Console.ReadLine();
//        bool result = int.TryParse(line, out idE);
//        if (result) GetElementById(employeeRepository, idE);
//        else GetElementByName(employeeRepository, line);
//        Console.ReadKey();
//    }

//    static void GetElementById(IRepository<Employee> employeeRepository, int x)
//    {
//        var employee = employeeRepository.GetById(x);
//        Console.WriteLine(employee.ToString());
//    }

//    void GetElementByName(IRepository<Employee> employeeRepository, string name)
//    {
//        //Console.WriteLine($"Jestem w GetByName name: {name}\n");
//        //List<Employee> employees = employeeRepository.GetAll().ToList();
//        GetAllEmployee(employeeRepository);
//        foreach (Employee employee in allEmployees)
//        {
//            //Console.WriteLine(employee.ToString());
//            string yName = employee.FirstName.Trim();
//            //Console.WriteLine(yName);
//            if (yName == name)
//            {
//                Console.WriteLine(employee.ToString());
//            }
//        }
//        //Console.ReadKey();
//    }

//    void GetAllEmployee(IRepository<Employee> employeeRepository)
//    {
//        allEmployees =  employeeRepository.GetAll().ToList();
//    }


//    void AddTool()
//    {
//        NotImplementedFunction();
//    }

//    void ShowAllTools()
//    {
//        NotImplementedFunction();
//    }

//    void FindTool()
//    {
//        NotImplementedFunction();
//    }


//    void ReadLogsToConsole()
//    {
//        Clear();
//        StreamReader reader = new StreamReader("ToolMonitorLogs.txt");
//        while (reader.EndOfStream == false)
//        {
//            string line = reader.ReadLine();
//            Console.WriteLine(line);
//        }
//        reader.Dispose();
//        Console.WriteLine("\nWciśnij dowolny klawisz.");
//        Console.ReadKey();
//    }

//    void EndApp()
//    {
//        Clear();
//        Console.WriteLine("    Dziękuję za kożystanie z programu ;)\n\n\n\n");
//    }


//#endregion

//#region EventHandler

//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
//    employeeRepository.ItemAdded += SaveLogToFile;
//    employeeRepository.ItemGetById += SaveLogGetByIdToFile;
//    employeeRepository.ItemRemoved += SaveLogRemovedToFile;
//    employeeRepository.ItemGetByName += SaveLogSearchToFile;


//    void SaveLogGetByIdToFile(object? sender, Employee e)
//    {
//        DateTime dateNow = DateTime.Now;
//        string log = $"[{dateNow}]- - - [ GetById ] - - -[{e.ToString()}]";
//        Console.WriteLine(log);
//        FileStream stream = new("ToolMonitorLogs.txt", FileMode.Append);
//        StreamWriter writer = new(stream);
//        writer.WriteLine(log);
//        writer.Dispose();
//    }

//    void SaveLogRemovedToFile(object? sender, Employee e)
//    {
//        DateTime dateNow = DateTime.Now;
//        string log = $"[{dateNow}]- - - [ Removed ] - - -[{e.Id} | {e.FirstName}]";
//        Console.WriteLine(log);
//        FileStream stream = new("ToolMonitorLogs.txt", FileMode.Append);
//        StreamWriter writer = new(stream);
//        writer.WriteLine(log);
//        writer.Dispose();
//    }


//    //FileRepository fileLog = new();
//    //fileLog.Save("Hello World");

//    void SaveLogToFile(object? sender, Employee e)
//    {
//        DateTime dateNow = DateTime.Now;
//        string log = $"[{dateNow}]- - - [  Added  ] - - -[{e.Id} | {e.FirstName}]";
//        Console.WriteLine(log);
//        //fileLog.Save(log);
//        FileStream stream = new("ToolMonitorLogs.txt", FileMode.Append);
//        StreamWriter writer = new(stream);
//        writer.WriteLine(log);
//        writer.Dispose();
//        //Console.WriteLine($"[{dateNow.ToString()}]--[{sender.GetType().Name}]--[{e.ToString()}]" ); 
//    }

//    void SaveLogSearchToFile(object? sender, Employee e)
//    {
//        DateTime dateNow = DateTime.Now;
//        string log = $"[{dateNow}]- - - [  Wanted  ] - - -[{e.Id} | {e.FirstName}]";
//        Console.WriteLine(log);
//        //fileLog.Save(log);
//        FileStream stream = new("ToolMonitorLogs.txt", FileMode.Append);
//        StreamWriter writer = new(stream);
//        writer.WriteLine(log);
//        writer.Dispose();
//    }

//    //SaveLog().fileLog;

//    void SaveLog(object? sender, Employee e)
//    {
//        DateTime dateNow = DateTime.Now;
//        string log = $"[{dateNow.ToString()}]-{sender.GetType().Name}-[{e.FirstName}]";
//        //fileLog.Save(log);

//    }

//    void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//    {
//        Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
//    }


//#endregion

//#region Helpers

//    static void EmployeeAdded(Employee item)
//    {
//        //var employee = item as Employee;
//        Console.WriteLine($"{item.FirstName} added.");
//    }

//    static void WriteAllToConsole(IReadRepository<IEntity> repository)
//    {
//        var items = repository.GetAll();
//        foreach (var employee in items)
//        {
//            Console.WriteLine(employee);
//        }
//    }


//#endregion

//#region STATIC_PROGRAM
    
//    //AddEmployees(employeeRepository);
//    //GetElementById(employeeRepository);
//    //WriteAllToConsole(employeeRepository);
//    //ReadLogsToConsole();

//    static void AddEmployees(IRepository<Employee> employeeRepository)
//    {
//        var employees = new[]
//        {
//            new Employee { FirstName = "Krzysiek" },
//            new Employee { FirstName = "Kuba"},
//            new Employee { FirstName = "Kacper"},
//            new Employee { FirstName = "Renata"}
//        };
//        employeeRepository.AddBatch(employees);

//        //AddBatch(employeeRepository, employees);

//        //employeeRepository.Add(new Employee { FirstName = "Krzysiek" });
//        //employeeRepository.Add(new Employee { FirstName = "Kuba" });
//        //employeeRepository.Add(new Employee { FirstName = "Kacper" });
//        //employeeRepository.Add(new Employee { FirstName = "Renata" });
//        //employeeRepository.Save();
//    }

//    //static void AddBatch<T>(IRepository<T> repository, T[] items) where T : class, IEntity
//    //{
//    //    foreach (var item in items)
//    //    {
//    //        repository.Add(item);
//    //    }
//    //    repository.Save();
//    //}

//#endregion