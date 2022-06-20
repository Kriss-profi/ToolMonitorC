namespace ToolMonitorC.Data.Entities
{
    public class User : EntityBase
    {
        public string UserVorName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public override string ToString()
        {
            return $"Id: {Id} | Name: {UserName} \t | email: {Email}";
        }
    }
}
