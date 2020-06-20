using System;
using System.Collections.Generic;
using System.Text;

namespace OPP_Zajecia
{
    public class Pracownik : Osoba
    {
        public Pracownik() { }
        public Pracownik(string Login, string Nazwisko, string Haslo, string Departament)
        {
            this.Nazwisko = Nazwisko;
            this.Login = Login;
            this.Departament = Departament;
            this.Haslo = Haslo;
        }
        public string Departament { get; set; }

        public void UstawHaslo(string noweHaslo)
        {
            this.Haslo = noweHaslo;
        }

    }
}
