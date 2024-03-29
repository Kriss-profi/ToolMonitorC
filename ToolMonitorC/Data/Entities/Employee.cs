﻿namespace ToolMonitorC.Data.Entities;

public class Employee : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int DepartmentId { get; set; }
    public override string ToString() => $"Id: {Id,2} | Name: {FirstName,10} {LastName,10} \tDział: {DepartmentId}";
}
