namespace ToolMonitorC.ConsolMenu
{
    public class Menu : IMenu
    {

        public void MainMenu()
        {
            Heading();
            Console.WriteLine("\t1. Employees.");
            Console.WriteLine("\t2. Departments.");
            Console.WriteLine("\t3. Tools.");
            Console.WriteLine("\t4. Categories.");
            End();
        }

        public void SubMenu(int subTitel)
        {
            SubHeading(subTitel);
            Console.WriteLine("Schow All[1]  Schow ID[2]  Serch[3]  Add[4] ");
            //Console.WriteLine("\t2. Pokaż po ID");
            //Console.WriteLine("\t3. Szukaj");
            //Console.WriteLine("\t4. Dodaj");
            SubEnd();
        }
        public void SubMenu1(int subTitel)
        {
            SubHeading(subTitel);
            Console.WriteLine("     Schow ID[2]  Serch[3]  Add[4] ");
            //Console.WriteLine("\t3. Szukaj");
            //Console.WriteLine("\t4. Dodaj");
            SubEnd();
        }
        public void SubMenu2(int subTitel)
        {
            SubHeading(subTitel);
            Console.WriteLine("\tEdytuj[5]   Usuń[6]");
            //Console.WriteLine("\t5. Usuń");
            SubEnd();
        }
        public void EndMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine("*****          TOOL MONITOR          ******");
            Console.WriteLine("*****         Chcesz opuścić         ******");
            Console.WriteLine("*****            Program?            ******");
            Console.WriteLine("*****       TAK(t)       NIE(n)      ******");
            Console.WriteLine("*******************************************");
            Console.WriteLine();
        }

        private static void Heading()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine("********     TOOL MONITOR MENU     ********");
            Console.WriteLine("*******************************************");
            Console.WriteLine();
        }

        public void SubHeading(int subTitel)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine("********     TOOL MONITOR MENU     ********");
            Console.WriteLine("*******************************************");
            switch(subTitel)
            {
                case 10:
                    Console.WriteLine("********      PRACOWNICY        ***********");
                    Console.WriteLine("*******************************************");
                    break;
                case 20:
                    Console.WriteLine("********        DZIAŁY          ***********");
                    Console.WriteLine("*******************************************");
                    break;
                case 30:
                    Console.WriteLine("********      NARZĘDZIA         ***********");
                    Console.WriteLine("*******************************************");
                    break;
                case 40:
                    Console.WriteLine("********      KATEGORIE         ***********");
                    Console.WriteLine("*******************************************");
                    break;
            }
            Console.WriteLine();
        }
        private static void End()
        {
            Console.WriteLine("\t -   -   -   -   -   -   -");
            Console.WriteLine("\t Zakończ program [0] ");
            Console.WriteLine("\t -   -   -   -   -   -   -");
        }
        private static void SubEnd()
        {
            Console.WriteLine("\t -   -   -   -   -   -   -");
            Console.WriteLine("\tPowrót do menu głównego [0]");
            Console.WriteLine("\t -   -   -   -   -   -   -");
        }
    }
}
