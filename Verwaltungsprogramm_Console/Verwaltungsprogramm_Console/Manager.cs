using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Verwaltungsprogramm_Console
{
    class Manager
    {
        private List<Person> allPersons;

        public void ShowCompleteList()
        {
            if (allPersons != null)
            {
                Console.WriteLine("\r\nAlle Personen in der Liste:");
                foreach (var person in allPersons)
                {
                    Console.WriteLine(person.ID + ": " + person.Name + ", " + person.Vorname + ", " + person.Geburtsdatum + ", " + person.Mail + ", " + person.Telefon);
                }
            }
            else
                Console.WriteLine("\r\nEs wurde noch keine Liste angelegt!");
            
            Console.WriteLine("\r\nZum fortfahren beliebige Taste drücken");
            Console.ReadKey();
        }

        public void AddNewPerson()
        {
            Console.WriteLine();
            if (allPersons == null)
                allPersons = new List<Person>();

            Person personToAdd = new Person();
            Console.WriteLine("Name: ");
            personToAdd.Name = Console.ReadLine();
            Console.WriteLine("Vorname: ");
            personToAdd.Vorname = Console.ReadLine();
            Console.WriteLine("Geburtsdatum: ");
            personToAdd.Geburtsdatum = Console.ReadLine();
            Console.WriteLine("Mail: ");
            personToAdd.Mail = Console.ReadLine();
            Console.WriteLine("Telefon: ");
            personToAdd.Telefon = Console.ReadLine();

            int? id = GetNewID();
            if (id != null)
                personToAdd.ID = (int)id;
            else
            {
                Console.WriteLine("Fehler beim  hinzufügen der Liste: Es konnte keine ID erzeugt werden");
                return;
            }

            allPersons.Add(personToAdd);
        }

        private int? GetNewID()
        {
            if (allPersons != null)
            {
                return allPersons.Count() + 1 ;
            }
            else
                return null;
        }

        public int GetCount()
        {
            if (allPersons != null)
                return allPersons.Count();
            else
                return 0;
        }
    }
}
