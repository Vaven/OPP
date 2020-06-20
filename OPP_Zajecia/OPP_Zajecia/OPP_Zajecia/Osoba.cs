using System;
using System.Collections.Generic;
using System.Text;

namespace OPP_Zajecia
{
    public class Osoba
    {
        public Osoba() { }
        public Osoba(string Login, string Haslo, string Nazwisko)
        {
            this.Login = Login;
            this.Login = Haslo;
            this.Login = Nazwisko;
        }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Nazwisko { get; set; }
    }
}
