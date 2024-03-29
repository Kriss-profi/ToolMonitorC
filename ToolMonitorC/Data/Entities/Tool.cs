﻿namespace ToolMonitorC.Data.Entities;

public class Tool : EntityBase
{
    public string ToolName { get; set; }
    public string ToolDescription { get; set; }
    public int ManufacturerId { get; set; }
    public int DealerId { get; set; }
    public int InvoiiceId { get; set; }
    public int Category { get; set; }
    public DateTime BayData { get; set; }
    public int Varanty { get; set; }

    //public List<string> ToolCategory { get; set; }

    //public override string ToString() => $"Id: {Id} | FirstName: {ToolName} \t | Opis: {ToolDescription} \t | Gwarancja: {Varanty}";
    public override string ToString() => $"Id: {Id} | Name: {ToolName}  \t | Gwarancja: {Varanty}";
}
