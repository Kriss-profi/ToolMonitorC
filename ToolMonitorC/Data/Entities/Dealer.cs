namespace ToolMonitorC.Data.Entities;

public class Dealer : EntityBase
{
    public string? Name { get; set; }
    public string? Web { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} | Dealer: {Name} \tWeb: {Web}";
    }
}
