using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolMonitorC.UI.HelpersUi
{
    public class HelpMethod : IHelpMethod
    {

        #region HELPERS
        public int GetNumber()
        {
            Console.Write("\tWybierz opcję: ");
            bool bn = int.TryParse(Console.ReadLine(), out int n);
            if (!bn)
            {
                n = 99;
            }
            //n = int.Parse(Console.ReadLine());
            return n;
        }
        public int GetSubNumber()
        {
            Console.Write("\tWybierz opcję: ");
            bool bn = int.TryParse(Console.ReadLine(), out int n);
            if (!bn)
            {
                n = 99;
            }
            return n;
        }

        public int GetId()
        {
            int id = -1;
            do
            {
                bool result = int.TryParse(Console.ReadLine(), out int temp);
                if (!result) { Console.Write("Podaj właściwą liczbę: "); }
                else { id = temp; }
            } while (id < 0);
            return id;
        }

        public void WriteLineInRed(string str)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(str, Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public string ReadString()
        {
            string str = "";
            bool trueString = false;
            do
            {
                var temp = Console.ReadLine();
                if (!string.IsNullOrEmpty(temp))
                {
                    str = temp;
                    trueString = true;
                }
                else
                {
                    Console.WriteLine("Nazwa nie może być pusta");
                }
            } while (!trueString);
            return str;
        }

        public void Display<T>(List<T> list)
        {
            if (list is null)
            {
                Console.WriteLine("Brak elementów do wyświetlenia"); ;
            }
            else
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }


        }


        #endregion
    }
}
