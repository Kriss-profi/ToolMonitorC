using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitorC.UI.HelpersUi
{
    public interface IHelpMethod
    {
        public int GetNumber();
        public int GetSubNumber();
        public int GetId();
        public void WriteLineInRed(string str);
        public string ReadString();
        public void Display<T>(List<T> list);
    }
}
