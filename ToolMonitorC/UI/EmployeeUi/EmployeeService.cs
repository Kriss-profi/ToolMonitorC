using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolMonitorC.ConsolMenu;
using ToolMonitorC.Data;
using ToolMonitorC.Data.Entities;
using ToolMonitorC.Data.Repositories;
using ToolMonitorC.UI;
using ToolMonitorC.UI.HelpersUi;
using ToolMonitorC.UI;

namespace ToolMonitorC.UI.EmployeeUi
{
    internal class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository;
        ToolMonitorDbContext toolMonitorDbContext;
        private Menu menu;
        private HelpMethod? help;
        Employee employee;
        const int MenuConst = 99;
        const int MenuTools = 10;
        const int MenuEmployee = 20;
        const int MenuDepartment = 30;
        const int MenuManufacturer = 40;
        const int MenuDealer = 50;
        private int nrMenu = MenuConst;
        private int subNr = MenuConst;
        private int id = 0;

        public EmployeeService(IRepository<Employee> employeeRepository, ToolMonitorDbContext toolMonitorDbContextDi, IMenu menu, IHelpMethod helpMethod)
        {
            _employeeRepository = employeeRepository;
            toolMonitorDbContext = toolMonitorDbContextDi;
            this.menu = (Menu?)menu;
            this.help = (HelpMethod?)helpMethod;
        }

        #region EMPLOYEE

        public int StartEmployee()
        {

            menu.SubMenu(nrMenu); subNr = help.GetNumber(); //GetNumber();
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
            return nrMenu;
        }
        private void FindAllEmployeesFromDb()
        {
            menu.SubMenu1(nrMenu);
            var allEmployees = toolMonitorDbContext.Employees.ToList();
            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }
            subNr = help.GetSubNumber();
        }

        private void FindEmployeeId()
        {
            Console.Write("Podaj ID pracownika: ");
            id = help.GetId();
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
            subNr = help.GetSubNumber();
        }
        private void FindEmployee()
        {
            menu.SubMenu1(nrMenu);
            Console.WriteLine("Szukamy pracownika");
            FindEmployeeName();
            subNr = help.GetSubNumber();
        }
        private void FindEmployeeName()
        {
            menu.SubMenu1(nrMenu);
            Console.Write("Podaj Frazę do przeszukania :");
            var str = Console.ReadLine();
            //var emp = toolMonitorDbContext.Employees.FirstOrDefault(s => s.FirstName.Contains(str) || s.LastName.Contains(str))!;
            var emp = toolMonitorDbContext.Employees
                .Where(s => s.FirstName.Contains(str) || s.LastName.Contains(str))
                .ToList()!;
            foreach (var employee in emp)
            {
                Console.WriteLine(employee);
            }
            //Console.WriteLine(emp.ToString());
            //subNr = GetSubNumber();
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
            if (!string.IsNullOrEmpty(temp))
            {
                employee.FirstName = temp;
            }
            toolMonitorDbContext.SaveChanges();
            subNr = help.GetSubNumber();
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
            help.WriteLineInRed(str);
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
            bool flag = false;
            menu.SubHeading(nrMenu);
            Employee employee = new Employee();
            do
            {
                Console.Write("Podaj imię: ");
                string name = Console.ReadLine();
                //name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name))
                {
                    employee.FirstName = name;
                    flag = true;
                }

            } while (!flag);
            Console.Write("Podaj Nazwisko: ");
            employee.LastName = Console.ReadLine();
            //AllDepartmentsFromDb();
            Console.Write("Wybierz Id Departamentu: ");
            int departmentId = help.GetId();
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

    }
}
