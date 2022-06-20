using ToolMonitorC.Data;
using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;
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
        private int nr = 99;
        private int subNr = 99;
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
                if (nr == 99)
                {
                    menu.MainMenu();
                    nr = GetNumber() * 10;
                }
                switch (nr)
                {
                    case 0:
                        {
                            menu.EndMenu();
                            var key = Console.ReadKey();
                            nr = key.Key == ConsoleKey.T ? -1 : 99;
                            break;
                        }
                    case 10: StartEmployee(); break;

                    case 20: StartDepartments(); break;

                    case 30: menu.SubMenu(nr); nr += GetNumber(); break;
                    case 31: break; // schow all
                    case 32: break; // schow Id
                    case 33: Find(); break;
                    case 34: break; // Add
                    case 35: Edit(); break; // Edit
                    case 36: Remove(); break; // Remove

                    case 40: menu.SubMenu(nr); nr += GetNumber(); break;
                    case 41: break; // schow all
                    case 42: break; // schow Id
                    case 43: Find(); break;
                    case 44: break; // Add
                    case 45: Edit(); break; // Edit
                    case 46: Remove(); break; // Remove

                    default: nr = 99; break;
                }
                Console.WriteLine($"nr : {nr}");
            } while (nr > 0);
        }


        #region EMPLOYEE

        private void StartEmployee()
        {
            menu.SubMenu(nr); subNr = GetNumber();
            do
            {
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

            nr = 99;
        }
        private void FindAllEmployeesFromDb()
        {
            nr = 10;
            menu.SubMenu1(nr);
            var EmployeeFromDb = toolMonitorDbContext.Employees.ToList();
            foreach (var employee in EmployeeFromDb)
            {
                Console.WriteLine(employee);
            }
            subNr = GetSubNumber();
        }

        private void FindEmployeeId()
        {
            nr = 10;
            Console.Write("Podaj ID pracownika: ");
            id = GetId();
            employee = toolMonitorDbContext.Employees.FirstOrDefault(x => x.Id == id)!;
            menu.SubMenu2(nr);
            if (employee != null)
            {
                Console.WriteLine(employee.ToString());
            }
            else
            {
                Console.WriteLine("No such employee was found");
            }
            subNr = GetSubNumber();
        }
        private void FindEmployee()
        {
            nr = 10;
            menu.SubMenu1(nr);
            Console.WriteLine("Szykamy pracownika");

            subNr = GetSubNumber();
        }

        private void FindEmployeeName()
        {
            //nr = 10;
            menu.SubMenu1(nr);
            Console.WriteLine("Szykamy . . . ");

            subNr = GetSubNumber();
        }
        private void EditEmployee()
        {
            nr = 10;
            menu.SubMenu1(nr);
            Console.WriteLine(employee.ToString());
            Console.Write("Podaj nowe imię: ");
            employee.FirstName = Console.ReadLine();
            toolMonitorDbContext.SaveChanges();
            subNr = GetSubNumber();
        }

        private void RemoveEmployee()
        {
            nr = 10;
            menu.SubMenu1(nr);
            Console.WriteLine("Usówanko");
            RemoveEmployee(id);
            subNr = 0;
        }
        private void RemoveEmployee(int id)
        {
            nr = 10;
            menu.SubHeading(nr);
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
            nr = 10;
            menu.SubHeading(nr);
            Employee employee = new Employee();
            Console.Write("Podaj imię: ");
            employee.FirstName = Console.ReadLine();
            toolMonitorDbContext.Add(employee);
            toolMonitorDbContext.SaveChanges();
            subNr = 0;
        }



        private void ReadAllToolsFromSql()
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
            menu.SubMenu(nr); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nr = -1; break;
                    case 1: FindAllDepartmentsFromDb(); break; // schow all
                    case 2: FindDepartmentId(); break; // schow Id
                    case 3: FindDepartment(); break;
                    case 4: AddDepartment(); break; // Add
                    case 5: EditDepartment(); break; // Edit
                    case 6: RemoveDepartment(); break; // Remove
                }
            } while (subNr > 0);

            nr = 99;
        }

        private void FindAllDepartmentsFromDb()
        {
            Console.WriteLine("Jeszcze nie ma tabelki");
        }

        private void FindDepartmentId()
        {
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

        #region TOOLS

        private void StartTools()
        {
            menu.SubMenu(nr); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nr = -1; break;
                    case 1: FindAllToolFromDb(); break; // schow all
                    case 2: FindId(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nr = 99;
        }

        private void FindAllToolFromDb()
        {
            throw new NotImplementedException();
        }

        private void FindId()
        {
            throw new NotImplementedException();
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

        #region TOOLS

        private void StartCategories()
        {
            menu.SubMenu(nr); subNr = GetNumber();
            do
            {
                switch (subNr)
                {
                    case 0: nr = -1; break;
                    case 1: FindAllCategoriesFromDb(); break; // schow all
                    case 2: FindId(); break; // schow Id
                    case 3: Find(); break;
                    case 4: Add(); break; // Add
                    case 5: Edit(); break; // Edit
                    case 6: Remove(); break; // Remove
                }
            } while (subNr > 0);

            nr = 99;
        }

        private void FindAllCategoriesFromDb()
        {
            throw new NotImplementedException();
        }

        private void FindIdC()
        {
            throw new NotImplementedException();
        }

        private void FindC()
        {
            throw new NotImplementedException();
        }

        private void AddC()
        {
            throw new NotImplementedException();
        }

        private void EditC()
        {
            throw new NotImplementedException();
        }

        private void RemoveC()
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
                if (!result) { Console.WriteLine("Podaj właściwą liczbę: "); }
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
