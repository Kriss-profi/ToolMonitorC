namespace ToolMonitorC.ConsolMenu
{
    public class Menu : IMenu
    {

        private string linia = " ------------------------------------------------";
        public void MainMenu()
        {
            Heading();
            Console.WriteLine("\t1. Tools.");
            Console.WriteLine("\t2. Employees.");
            Console.WriteLine("\t3. Departments.");
            Console.WriteLine("\t4. Categories.");
            Console.WriteLine("\t5. Manufactures.");
            Console.WriteLine("\t6. Dealers.");
            Console.WriteLine("\t7. Invoice.");
            
            End();
        }

        public void SubMenu(int subTitel)
        {
            SubHeading(subTitel);
            TextGreen(linia);
            ElementGreen("|");
            Console.Write($" Schow All[1] ");
            ElementGreen("|");
            Console.Write($" Schow ID[2] ");
            ElementGreen("|");
            Console.Write($" Serch[3] ");
            ElementGreen("|");
            Console.Write($" Add[4] ");
            ElementGreen("|");
            Console.WriteLine();
            TextGreen(linia);
            SubEnd();
        }
        public void SubMenu1(int subTitel)
        {
            SubHeading(subTitel);
            TextGreen(linia);
            ElementGreen("|");
            Console.Write("   Schow ID[2]  ");
            ElementGreen("|");
            Console.Write("    Serch[3]   ");
            ElementGreen("|");
            Console.Write("     Add[4]    ");
            ElementGreen("|");
            Console.WriteLine();
            TextGreen(linia);
            SubEnd();
        }
        public void SubMenuElement(int subTitel)
        {
            SubHeading(subTitel);
            TextGreen(linia);
            ElementGreen("|");
            Console.Write("\t Edytuj[5]  ");
            ElementGreen("\t|");
            Console.Write("\t Usuń[6] ");
            ElementGreen("\t |");
            Console.WriteLine();
            TextGreen(linia);
            SubEnd();
        }
        public void EndMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*****              TOOL MONITOR             ******");
            Console.WriteLine("*****             Chcesz opuścić            ******");
            Console.WriteLine("*****                Program?               ******");
            Console.WriteLine("*****           TAK(t)       NIE(n)         ******");
            Console.WriteLine("**************************************************");
            Console.WriteLine();
        }

        private static void Heading()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("********         TOOL MONITOR MENU        ********");
            Console.WriteLine("**************************************************");
            Console.WriteLine();
        }

        public void SubHeading(int subTitel)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("********         TOOL MONITOR MENU        ********");
            Console.WriteLine("**************************************************");
            switch(subTitel)
            {
                case 10:
                    Console.WriteLine("********           NARZĘDZIA           ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 20:
                    Console.WriteLine("********           PRACOWNICY          ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 30:
                    Console.WriteLine("********             DZIAŁY            ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 40:
                    Console.WriteLine("********            KATEGORIE          ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 50:
                    Console.WriteLine("********            PRODUCENT          ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 60:
                    Console.WriteLine("********           SPRZEDAWCA          ***********");
                    Console.WriteLine("**************************************************");
                    break;
                case 70:
                    Console.WriteLine("********            RACHUNKI           ***********");
                    Console.WriteLine("**************************************************");
                    break;
            }
            //Console.WriteLine();
        }
        private void End()
        {
            TextGreen(linia);
            ElementGreen("|");
            Console.Write("\t         Zakończ program [0]             ");
            ElementGreen("|");
            Console.WriteLine();
            TextGreen(linia);
        }
        private void SubEnd()
        {
            ElementGreen("|");
            Console.Write("\t     Powrót do menu głównego [0]         ");
            ElementGreen("|");
            Console.WriteLine();
            TextGreen(linia);
        }
        private void TextGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ElementGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
