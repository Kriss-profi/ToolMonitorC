using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitorC.Repositories.Extensions
{
    public class FileRepository
    {
        public void Save(string log)
        {
            try
            {
                Console.Clear();
                FileStream stream = new("ToolMonitorLogs.txt", FileMode.Append);
                StreamWriter writer = new(stream);
                writer.WriteLine(log);
                writer.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd zapisu: {ex}");
                Console.ReadKey();
            }
        }
    }
}
