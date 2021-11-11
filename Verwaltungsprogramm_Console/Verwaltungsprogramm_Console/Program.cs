using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Verwaltungsprogramm_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Manager manager = new Manager();
            List<Person> p = LoadFromDisk();
            if (p != null)
                manager.allPersons = p;
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
                        manager.DisplaySinglePerson(manager.SearchPerson());
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        manager.EditPerson(manager.SearchPerson());
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        manager.DeletePerson(manager.SearchPerson());
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        SaveToDisk(manager.allPersons);
                        run = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SaveToDisk(List<Person> l)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using(var sww = new StringWriter())
            {
                using(XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, l);
                    string xml = sww.ToString();
                    File.WriteAllText("xml.xml", xml);
                }
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Mitgliederliste.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, l);
            stream.Close(); 
        }
        private static List<Person> LoadFromDisk()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Mitgliederliste.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Person> returnList = (List<Person>)formatter.Deserialize(stream);
                stream.Close();
                return returnList;
            }
            catch (Exception e)
            {
                return null;
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
