namespace ToolMonitorC.Data.Entities;

public class Manufacturer : EntityBase
{
    public string Name { get; set; }
    public string Web { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} | Manufacturer: {Name} \tWeb: {Web}";
    }
}
