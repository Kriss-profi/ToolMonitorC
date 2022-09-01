using ToolMonitorC.Data;
using ToolMonitorC.Data.Entities;
using ToolMonitorC.Data.Repositories;
using ToolMonitorC.ConsolMenu;
using System.Net;
using System.Collections.Generic;
using ToolMonitorC.UI.EmployeeUi;

namespace ToolMonitorC.UI
{
    public class App : IApp
    {

        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Tool> toolRepository;
        private readonly ToolMonitorDbContext toolMonitorDbContext;
        private readonly Menu menu = new();
        private Employee employee;
        private EmployeeService employeeService;
        private Tool tool;
        const int MenuConst = 99;
        const int MenuTools = 10;
        const int MenuEmployee = 20;
        const int MenuDepartment = 30;
        const int MenuManufacturer = 40;
        const int MenuDealer = 50;
        private int nrMenu = MenuConst;
        private int subNr = MenuConst;
        private int id = 0;

        public App(
            IRepository<Employee> employeeRepository, 
            IRepository<Tool> toolRepository, 
            ToolMonitorDbContext toolMonitorDbContext, 
            IEmployeeService es)
        {
            this.employeeRepository = employeeRepository;
            this.toolRepository = toolRepository;
            this.toolMonitorDbContext = toolMonitorDbContext;
            toolMonitorDbContext.Database.EnsureCreated();
            this.employeeService = (EmployeeService?)es;
        }
        public void Run()
        {
            do
            {
                if (nrMenu == 99)
                {
                    menu.MainMenu();
                    nrMenu = GetNumber() * 10;
                }
                switch (nrMenu)
                {
                    case 0:
                        {
                            menu.EndMenu();
                            var key = Console.ReadKey();
                            nrMenu = (key.Key == ConsoleKey.T || key.Key == ConsoleKey.Enter) ? -1 : MenuConst;
                            break;
                        }
                    case 10: StartTools(); break;

                    case 20: nrMenu = employeeService.StartEmployee(); break;

                    case 30: StartDepartments(); break;

                    case 40: StartCategories(); break;

                    case 50: menu.SubMenu(nrMenu); nrMenu += GetNumber(); break;

                    default: nrMenu = MenuConst; break;
                }
                Console.WriteLine($"nr : {nrMenu}");
            } while (nrMenu > 0);
        }


        #region TOOLS

        private void StartTools()
        {
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                nrMenu = MenuTools;
                switch (subNr)
                {
                    case 0: nrMenu = -1; break;
                    case 1: FindAllToolsFromDb();  break; // schow all
                    case 2: FindIdTool(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = 99;
        }

        private void FindAllToolsFromDb()
        {
            menu.SubMenu(nrMenu);
            var allTools = AllToolsFromDb();
            foreach (var item in allTools)
            {
                Console.WriteLine(item);
            }
            subNr = GetNumber();
        }

        private List<Tool> AllToolsFromDb()
        {
            return toolMonitorDbContext.Tools.ToList();
            //foreach (var toolFromDb in AllToolsFromDb)
            //{
            //    Console.WriteLine(toolFromDb);
            //}
            //return AllToolsFromDb;
        }

        private void FindIdTool()
        {
            Console.Write("Podaj ID Narzedzia: ");
            id = GetId();
            tool = toolMonitorDbContext.Tools.FirstOrDefault(x => x.Id == id)!;
            menu.SubMenu2(nrMenu);
            if (tool == null)
            {
                Console.WriteLine("No such Tool was found");
            }
            else
            {
                Console.WriteLine(tool.ToString());
            }
        }

        private void Find()
        {
            Console.WriteLine("Podaj nazwę narzędzia które chcesz znaleźć:");
            var str = Console.ReadLine();
            var tools = toolMonitorDbContext.Tools.FirstOrDefault(s => s.ToolName.Contains(str) || s.ToolDescription.Contains(str))!;

            if( tools == null)
            { Console.WriteLine("nima!"); }
            else { Console.WriteLine(tools); }
        }

        private void Add()
        {
            throw new NotImplementedException();
        }

        private void Edit()
        {
            throw new NotImplementedException();
        }

        private void Remove()
        {
            throw new NotImplementedException();
        }

        #endregion

        //#region EMPLOYEE

        //private void StartEmployee()
        //{
            
        //    menu.SubMenu(nrMenu); subNr = GetNumber();
        //    do
        //    {
        //        nrMenu = MenuEmployee;
        //        switch (subNr)
        //        {
        //            case 0: subNr = -1; break;
        //            case 1: FindAllEmployeesFromDb(); break; // schow all
        //            case 2: FindEmployeeId(); break; // schow Id
        //            case 3: FindEmployee(); break;
        //            case 4: AddEmployee(); break; // Add
        //            case 5: EditEmployee(); break; // Edit
        //            case 6: RemoveEmployee(); break; // Remove
        //        }
        //    } while (subNr > 0);

        //    nrMenu = MenuConst;
        //}
        //private void FindAllEmployeesFromDb()
        //{
        //    menu.SubMenu1(nrMenu);
        //    var allEmployees = toolMonitorDbContext.Employees.ToList();
        //    foreach (var employee in allEmployees)
        //    {
        //        Console.WriteLine(employee);
        //    }
        //    subNr = GetSubNumber();
        //}

        //private void FindEmployeeId()
        //{
        //    Console.Write("Podaj ID pracownika: ");
        //    id = GetId();
        //    employee = toolMonitorDbContext.Employees.FirstOrDefault(x => x.Id == id)!;
        //    menu.SubMenu2(nrMenu);
        //    if (employee == null)
        //    {
        //        Console.WriteLine("No such employee was found");
        //    }
        //    else
        //    {
        //        Console.WriteLine(employee.ToString());
        //    }
        //    subNr = GetSubNumber();
        //}
        //private void FindEmployee()
        //{
        //    menu.SubMenu1(nrMenu);
        //    Console.WriteLine("Szukamy pracownika");
        //    FindEmployeeName(); 
        //    subNr = GetSubNumber();
        //}
        //private void FindEmployeeName()
        //{
        //    menu.SubMenu1(nrMenu);
        //    Console.Write("Podaj Frazę do przeszukania :");
        //    var str = Console.ReadLine();
        //    //var emp = toolMonitorDbContext.Employees.FirstOrDefault(s => s.FirstName.Contains(str) || s.LastName.Contains(str))!;
        //    var emp = toolMonitorDbContext.Employees
        //        .Where(s => s.FirstName.Contains(str) || s.LastName.Contains(str))
        //        .ToList()!;
        //    foreach (var employee in emp)
        //    {
        //        Console.WriteLine(employee);
        //    }
        //    //Console.WriteLine(emp.ToString());
        //    //subNr = GetSubNumber();
        //}
        //private void EditEmployee()
        //{
        //    string temp = "";
        //    menu.SubMenu1(nrMenu);
        //    Console.WriteLine(employee.ToString());
        //    Console.Write("Podaj nowe imię: ");
        //    temp = Console.ReadLine();
        //    Console.WriteLine(string.IsNullOrEmpty(temp));
        //    Console.ReadKey();
        //    if(!string.IsNullOrEmpty(temp))
        //    {
        //        employee.FirstName = temp;
        //    }
        //    toolMonitorDbContext.SaveChanges();
        //    subNr = GetSubNumber();
        //}
        //private void RemoveEmployee()
        //{
        //    menu.SubMenu1(nrMenu);
        //    Console.WriteLine("Usówanko");
        //    RemoveEmployee(id);
        //    subNr = 0;
        //}
        //private void RemoveEmployee(int id)
        //{
        //    menu.SubHeading(nrMenu);
        //    string str = $"Do you want to delete it : \n{employee.ToString()}";
        //    WriteLineInRed(str);
        //    Console.WriteLine("  TAK [t] \t NIE [n]");
        //    var key = Console.ReadKey();
        //    if (key.Key == ConsoleKey.T)
        //    {
        //        RemoveEmployeeFromDb(employee);
        //    }
        //}
        //private void RemoveEmployeeFromDb(Employee employee)
        //{
        //    toolMonitorDbContext.Employees.Remove(employee);
        //    toolMonitorDbContext.SaveChanges();
        //}
        //private void AddEmployee()
        //{
        //    bool flag = false;
        //    menu.SubHeading(nrMenu);
        //    Employee employee = new Employee();
        //    do
        //    {
        //        Console.Write("Podaj imię: ");
        //        string name = Console.ReadLine();
        //        //name = Console.ReadLine();
        //        if (!String.IsNullOrEmpty(name))
        //        {
        //            employee.FirstName = name;
        //            flag = true;
        //        }

        //    } while (!flag);
        //    Console.Write("Podaj Nazwisko: ");
        //    employee.LastName = Console.ReadLine();
        //    AllDepartmentsFromDb(); 
        //    Console.Write("Wybierz Id Departamentu: ");
        //    int departmentId = GetId();
        //    employee.DepartmentId = departmentId;
        //    toolMonitorDbContext.Add(employee);
        //    toolMonitorDbContext.SaveChanges();
        //    subNr = 0;
        //}

        //private void ReadAllToolsFromDb()
        //{
        //    var ToolsFromDb = toolMonitorDbContext.Tools.ToList();
        //    foreach (var tool in ToolsFromDb)
        //    {
        //        Console.WriteLine(tool);
        //    }
        //}
        //#endregion

        #region DEPARTMENTS

        private void StartDepartments()
        {
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                nrMenu = MenuDepartment;
                switch (subNr)
                {
                    case 0: nrMenu = -1; break;
                    case 1: FindAllDepartmentsFromDb(); break; // schow all
                    case 2: FindDepartmentId(); break; // schow Id
                    case 3: FindDepartment(); break;
                    case 4: AddDepartment(); break; // Add
                    case 5: EditDepartment(); break; // Edit
                    case 6: RemoveDepartment(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = MenuConst;
        }

        private void FindAllDepartmentsFromDb()
        {
            menu.SubMenu(nrMenu);
            AllDepartmentsFromDb();
            subNr = GetNumber();

        }

        private void AllDepartmentsFromDb()
        {
            var allDepartments = toolMonitorDbContext.Departments.ToList();
            Display(allDepartments);
            //foreach (var department in allDepartments)
            //{
            //    Console.WriteLine(department);
            //}
        }

        private void FindDepartmentId()
        {
            Console.WriteLine("Jeszcze nie ma tabelki");
            throw new NotImplementedException();
        }

        private void FindDepartment()
        {
            throw new NotImplementedException();
        }

        private void AddDepartment()
        {
            menu.SubMenu(nrMenu);
            Console.Write("Podaj nazwę działu:");
            Department department = new Department();
            department.DepartmentName = ReadString();
            toolMonitorDbContext.Departments.Add(department);
            toolMonitorDbContext.SaveChanges();
            subNr = 1;
        }

        private void EditDepartment()
        {
            throw new NotImplementedException();
        }

        private void RemoveDepartment()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CATEGORIES

        private void StartCategories()
        {
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nrMenu = -1; break;
                    case 1: FindAllCategoriesFromDb(); break; // schow all
                    case 2: Find(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = 99;
        }

        private void FindAllCategoriesFromDb()
        {
            var allCategories = toolMonitorDbContext.Categories.ToList();
            if (allCategories.Any())
            {
                Display(allCategories);
            }
            else
            {
                Console.WriteLine(" ");
            }
        }

        private void FindIdCategories()
        {
            throw new NotImplementedException();
        }

        private void FindCategories()
        {
            throw new NotImplementedException();
        }

        private void AddCategories()
        {
            throw new NotImplementedException();
        }

        private void EditCategories()
        {
            throw new NotImplementedException();
        }

        private void RemoveCategories(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MANUFACTURES

        private void StartManufactures()
        {
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nrMenu = -1; break;
                    case 1: FindAllManufacturesFromDb(); break; // schow all
                    case 2: Find(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = 99;
        }

        private void FindAllManufacturesFromDb()
        {
            throw new NotImplementedException();
        }

        private void FindIdManufactures()
        {
            throw new NotImplementedException();
        }

        private void FindManufacture()
        {
            throw new NotImplementedException();
        }

        private void AddManufacture()
        {
            throw new NotImplementedException();
        }

        private void EditManufacture()
        {
            throw new NotImplementedException();
        }

        private void RemoveManufacture(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DEALERS

        private void StartDealers()
        {
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nrMenu = -1; break;
                    case 1: FindAllDealersFromDb(); break; // schow all
                    case 2: Find(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = 99;
        }

        private void FindAllDealersFromDb()
        {
            throw new NotImplementedException();
        }

        private void FindIdDealers()
        {
            throw new NotImplementedException();
        }

        private void FindDealers()
        {
            throw new NotImplementedException();
        }

        private void AddDealers()
        {
            throw new NotImplementedException();
        }

        private void EditDealers()
        {
            throw new NotImplementedException();
        }

        private void RemoveDealers(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region HELPERS
        private int GetNumber()
        {
            Console.Write("\tWybierz opcję: ");
            bool bn = int.TryParse(Console.ReadLine(), out int n);
            if (!bn)
            {
                n = 99;
            }
            //n = int.Parse(Console.ReadLine());
            return n;
        }
        static int GetSubNumber()
        {
            Console.Write("\tWybierz opcję: ");
            bool bn = int.TryParse(Console.ReadLine(), out int n);
            if (!bn)
            {
                n = 99;
            }
            return n;
        }

        private int GetId()
        {
            int id = -1;
            do
            {
                bool result = int.TryParse(Console.ReadLine(), out int temp);
                if (!result) { Console.Write("Podaj właściwą liczbę: "); }
                else { id = temp; }
            } while (id < 0);
            return id;
        }

        private void WriteLineInRed(string str)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(str, Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private string ReadString()
        {
            string str = "";
            bool trueString = false;
            do
            {
                var temp = Console.ReadLine();
                if (!string.IsNullOrEmpty(temp))
                {
                    str = temp;
                    trueString = true;
                }
                else
                {
                    Console.WriteLine("Nazwa nie może być pusta");
                }
            } while (!trueString);
            return str;
        }

        private void Display<T>(List<T> list)
        {
            if (list is null)
            {
                Console.WriteLine("Brak elementów do wyświetlenia"); ;
            }
            else
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }

 
        }


        #endregion
    }

    public static class Helpers
    {        
        public static void Display<T>(IEnumerable<T> ts)
        {
            foreach (var t in ts)
            { Console.WriteLine(t.ToString()); }
        }
        public static void Display<T>(this Object ots)
        {
            Console.WriteLine(ots.ToString());
        }

    }
}
