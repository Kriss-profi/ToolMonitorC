namespace ToolMonitorC.Entities
{
    internal class User : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {UserName} \t | email: {Email}";
        }
    }
}
