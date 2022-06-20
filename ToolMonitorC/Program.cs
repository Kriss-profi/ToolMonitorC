using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolMonitorC.Data;
using ToolMonitorC.Entities;
using ToolMonitorC.Repositories;
using ToolMonitorC.UI;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Tool>, ListRepository<Tool>>();
services.AddDbContext<ToolMonitorDbContext>(options => options.UseSqlServer("Data Source=KRISS\\SQLEXPRESS;Initial Catalog=ToolMonitorCStorage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();