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
        public int GetNumber(int success)
        {
            if (success != 0 && success != 0)
            {
                Console.Write("\tWybierz opcję: ");
                bool bn = int.TryParse(Console.ReadLine(), out int n);
                if (!bn)
                {
                    n = 99;
                }
                //n = int.Parse(Console.ReadLine());
                return n;
            }else
            {
                return success;
            }
        }
        public int GetIdNew()
        {
            int id = -1;
            do
            {
                var readLineResult = Console.ReadLine();
                if (readLineResult == null) { return -1; }
                else
                {
                    bool result = int.TryParse(readLineResult, out int temp);
                    if (!result) { Console.Write("Podaj właściwą liczbę: "); }
                    else { id = temp; }
                }
            } while (id < 0);
            return id;
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
        public void WriteInRed(string str)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(str, Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void WriteLineInGreen(string str)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(str, Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void WriteInGreen(string str)
        {
            Console.BackgroundColor = ConsoleColor.Green;
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

        //public static void ForeachThis<T>(this IEnumerable<T> t)
        //{
        //    Console.WriteLine("Uwaga drukuję");
        //    foreach (var item in t)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        #endregion
    }
}
