﻿namespace ToolMonitorC.Data.Entities;

public class Category : EntityBase
{
    public string? CategoryName { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} | Name: {CategoryName}";
    }
}
