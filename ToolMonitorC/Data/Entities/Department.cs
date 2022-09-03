namespace ToolMonitorC.Data.Entities;

public class Department : EntityBase
{
    public string? DepartmentName { get; set; }

    public override string ToString() => $"\tId: {Id,3} | Dział: {DepartmentName,10:10}";
}
