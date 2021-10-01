using System;

namespace Verwaltungsprogramm_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Manager manager = new Manager();
            while (run)
            {
                ResetView(manager);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        manager.AddNewPerson();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        manager.ShowCompleteList();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        run = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ResetView(Manager manager)
        {
            string welcomeString =
$@"
+-------------------------------+
|  Mega nice Personenverwaltung |
+---------------+---------------+-------------+-----------------+--------------+-------------+
|  Erfassen(1)  |  Anzeigen(2)  |  Suchen(3)  |  Bearbeiten(4)  |  Löschen(5)  | Beenden(0)  |
+---------------+---------------+-------------+-----------------+--------------+-------------+
";

            Console.Clear();
            Console.WriteLine(welcomeString);
            Console.WriteLine("Einträge: " + manager.GetCount());
        }
    }
}
