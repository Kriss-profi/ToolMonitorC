namespace ToolMonitorC.Data.Entities;

public class Employee : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentId { get; set; }
    public override string ToString() => $"Id: {Id} | Name: {FirstName} {LastName} \tDział: {DepartmentId}";
}
