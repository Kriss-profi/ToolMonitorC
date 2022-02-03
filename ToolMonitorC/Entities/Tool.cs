namespace ToolMonitorC.Entities
{
    internal class Tool : EntityBase
    {
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
        public int Varanty { get; set; }

        public override string ToString() => $"Id: {Id} | FirstName: {ToolName} \t | Opis: {ToolDescription} \t | Gwarancja: {Varanty}";
    }
}
