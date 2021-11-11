using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Verwaltungsprogramm_Console
{
    class Manager
    {
        public List<Person> allPersons;

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

        public void DisplaySinglePerson(Person person)
        {
            if (person == null)
                return;
            
            Console.WriteLine("ID: " + person.ID + ": " + person.Name + ", " + person.Vorname + ", " + person.Geburtsdatum + ", " + person.Mail + ", " + person.Telefon);
            
            Console.WriteLine("\r\nZum fortfahren beliebige Taste drücken");
            Console.ReadKey();
        }
        
        public Person SearchPerson()
        {
            Console.WriteLine("Person suchen:");
            string Name, Vorname;
            Console.WriteLine("Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Voname:");
            Vorname = Console.ReadLine();

            List<Person> foundPersons = allPersons
                .Where(x => x.Name.ToLower() == Name.ToLower() && x.Vorname.ToLower() == Vorname.ToLower()).ToList();
            if (foundPersons.Count() != 0)
            {
                if (foundPersons.Count() == 1)
                {
                    return foundPersons[0];
                }
                else
                {
                    Console.WriteLine("Mehrere Personen gefunden");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Keine Person gefunden");
                return null;
            }
        }

        public void DeletePerson(Person person)
        {
            if(person == null)
                return;
            
            allPersons.Remove(person);
            Console.WriteLine("Eintrag erfolgreich gelöscht");
            Console.WriteLine("\r\nZum fortfahren beliebige Taste drücken");
            Console.ReadKey();
        }

        public void EditPerson(Person person)
        {
            if (person == null)
                return;
            string input = "";
            Console.WriteLine();
            Console.WriteLine("Person bearbeiten: ");
            Console.WriteLine("Name: " + "'" + person.Name + "'");
            input = Console.ReadLine();
            input = input != null ? person.Name = input : person.Name = person.Name;
            Console.WriteLine("Vorname: ");
            input = Console.ReadLine();
            input = input != null ? person.Vorname = input : person.Vorname = person.Name;
            Console.WriteLine("Geburtsdatum: ");
            input = Console.ReadLine();
            input = input != null ? person.Geburtsdatum = input : person.Geburtsdatum = person.Name;
            Console.WriteLine("Mail: ");
            input = Console.ReadLine();
            input = input != null ? person.Mail = input : person.Mail = person.Name;
            Console.WriteLine("Telefon: ");
            input = Console.ReadLine();
            input = input != null ? person.Telefon = input : person.Telefon = person.Name;
            
            Console.WriteLine("Eintrag erfolgreich geändert!");
            Console.WriteLine("\r\nZum fortfahren beliebige Taste drücken");
            Console.ReadKey();
        }
    }
}
