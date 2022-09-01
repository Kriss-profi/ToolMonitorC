using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolMonitorC.ConsolMenu;
using ToolMonitorC.Data;
using ToolMonitorC.Data.Entities;
using ToolMonitorC.Data.Repositories;
using ToolMonitorC.UI;
using ToolMonitorC.UI.EmployeeUi;
using ToolMonitorC.UI.HelpersUi;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IMenu, Menu>();
services.AddSingleton<IHelpMethod, HelpMethod>();
services.AddSingleton<IEmployeeService, EmployeeService>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Tool>, ListRepository<Tool>>();
services.AddDbContext<ToolMonitorDbContext>(options => options.UseSqlServer("Data Source=KRISS\\SQLEXPRESS;Initial Catalog=ToolMonitorCStorage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
//var EmployeeServices = serviceProvider.GetService<IEmployeeService>();

app.Run();