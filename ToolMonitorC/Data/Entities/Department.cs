namespace ToolMonitorC.Data.Entities;

public class Department : EntityBase
{
    public string DepartmentName { get; set; }

    public override string ToString() => $"Id: {Id} | Dział: {DepartmentName}";
}
