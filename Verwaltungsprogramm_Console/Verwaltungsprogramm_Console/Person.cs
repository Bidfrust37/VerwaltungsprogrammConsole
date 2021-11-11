using System;
using System.Collections.Generic;
using System.Text;

namespace Verwaltungsprogramm_Console
{
    [Serializable]
    public class Person
    {
        public int ID;
        public string Name;
        public string Vorname;
        public string Geburtsdatum;
        public string Mail;
        public string Telefon;

        public Person()
        { }

        public Person(string _name, string _vorname, string _geburtstag, string _mail, string _telefon)
        {
            Name = _name;
            Vorname = _vorname;
            Geburtsdatum = _geburtstag;
            Mail = _mail;
            Telefon = _telefon;
        }
    }
}
