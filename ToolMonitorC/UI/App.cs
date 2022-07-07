using ToolMonitorC.Data;
using ToolMonitorC.Data.Entities;
using ToolMonitorC.Data.Repositories;
using ToolMonitorC.ConsolMenu;

namespace ToolMonitorC.UI
{
    public class App : IApp
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Tool> toolRepository;
        private readonly ToolMonitorDbContext toolMonitorDbContext;
        private readonly Menu menu = new();
        private Employee employee;
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

        public App(IRepository<Employee> employeeRepository, IRepository<Tool> toolRepository, ToolMonitorDbContext toolMonitorDbContext)
        {
            this.employeeRepository = employeeRepository;
            this.toolRepository = toolRepository;
            this.toolMonitorDbContext = toolMonitorDbContext;
            toolMonitorDbContext.Database.EnsureCreated();
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

                    case 20: StartEmployee(); break;

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
                    case 1: FindAllToolsFromDb(); break; // schow all
                    case 2: Find(); break; // schow Id
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
            AllToolsFromDb();
            subNr = GetNumber();
        }

        private void AllToolsFromDb()
        {
            var AllToolsFromDb = toolMonitorDbContext.Tools.ToList();
            foreach (var toolFromDb in AllToolsFromDb)
            {
                Console.WriteLine(toolFromDb);
            }
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
            throw new NotImplementedException();
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

        #region EMPLOYEE

        private void StartEmployee()
        {
            
            menu.SubMenu(nrMenu); subNr = GetNumber();
            do
            {
                nrMenu = MenuEmployee;
                switch (subNr)
                {
                    case 0: subNr = -1; break;
                    case 1: FindAllEmployeesFromDb(); break; // schow all
                    case 2: FindEmployeeId(); break; // schow Id
                    case 3: FindEmployee(); break;
                    case 4: AddEmployee(); break; // Add
                    case 5: EditEmployee(); break; // Edit
                    case 6: RemoveEmployee(); break; // Remove
                }
            } while (subNr > 0);

            nrMenu = MenuConst;
        }
        private void FindAllEmployeesFromDb()
        {
            menu.SubMenu1(nrMenu);
            var allEmployees = toolMonitorDbContext.Employees.ToList();
            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }
            subNr = GetSubNumber();
        }

        private void FindEmployeeId()
        {
            Console.Write("Podaj ID pracownika: ");
            id = GetId();
            employee = toolMonitorDbContext.Employees.FirstOrDefault(x => x.Id == id)!;
            menu.SubMenu2(nrMenu);
            if (employee == null)
            {
                Console.WriteLine("No such employee was found");
            }
            else
            {
                Console.WriteLine(employee.ToString());
            }
            subNr = GetSubNumber();
        }
        private void FindEmployee()
        {
            menu.SubMenu1(nrMenu);
            Console.WriteLine("Szykamy pracownika");

            subNr = GetSubNumber();
        }

        private void FindEmployeeName()
        {
            menu.SubMenu1(nrMenu);
            Console.WriteLine("Szykamy . . . ");

            subNr = GetSubNumber();
        }
        private void EditEmployee()
        {
            string temp = "";
            menu.SubMenu1(nrMenu);
            Console.WriteLine(employee.ToString());
            Console.Write("Podaj nowe imię: ");
            temp = Console.ReadLine();
            Console.WriteLine(string.IsNullOrEmpty(temp));
            Console.ReadKey();
            if(!string.IsNullOrEmpty(temp))
            {
                employee.FirstName = temp;
            }
            toolMonitorDbContext.SaveChanges();
            subNr = GetSubNumber();
        }

        private void RemoveEmployee()
        {
            menu.SubMenu1(nrMenu);
            Console.WriteLine("Usówanko");
            RemoveEmployee(id);
            subNr = 0;
        }
        private void RemoveEmployee(int id)
        {
            menu.SubHeading(nrMenu);
            string str = $"Do you want to delete it : \n{employee.ToString()}";
            WriteLineInRed(str);
            Console.WriteLine("  TAK [t] \t NIE [n]");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.T)
            {
                RemoveEmployeeFromDb(employee);
            }
        }

        private void RemoveEmployeeFromDb(Employee employee)
        {
            toolMonitorDbContext.Employees.Remove(employee);
            toolMonitorDbContext.SaveChanges();
        }


        private void AddEmployee()
        {

            menu.SubHeading(nrMenu);
            Employee employee = new Employee();
            Console.Write("Podaj imię: ");
            string name = Console.ReadLine();
            name = Console.ReadLine();
            if (String.IsNullOrEmpty(name))
            {
                employee.FirstName = name;
            }
            Console.Write("Podaj Nazwisko: ");
            employee.LastName = Console.ReadLine();
            AllDepartmentsFromDb(); 
            Console.Write("Wybierz Id Departamentu: ");
            int departmentId = GetId();
            employee.DepartmentId = departmentId;
            toolMonitorDbContext.Add(employee);
            toolMonitorDbContext.SaveChanges();
            subNr = 0;
        }



        private void ReadAllToolsFromDb()
        {
            var ToolsFromDb = toolMonitorDbContext.Tools.ToList();
            foreach (var tool in ToolsFromDb)
            {
                Console.WriteLine(tool);
            }
        }
        #endregion

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
            foreach(var department in allDepartments)
            {
                Console.WriteLine(department);
            }
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        private void EditCcategories()
        {
            throw new NotImplementedException();
        }

        private void RemoveCcategories(int id)
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

        #endregion
    }
}
