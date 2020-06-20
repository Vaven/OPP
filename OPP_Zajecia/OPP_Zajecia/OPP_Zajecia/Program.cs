using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OPP_Zajecia
{
    class Program
    {

        static void Main(string[] args)
        {

            Pracownicy pracownicyLogika = new Pracownicy();

            List<Pracownik> pracownicy = new List<Pracownik>();
            foreach (string element in InicjujPracownikow())
            {
                try
                {
                    pracownicy.Add(new Pracownik()
                    {
                        Login = element.Split("||")[0],
                        Nazwisko = element.Split("||")[1],
                        Haslo = element.Split("||")[2],
                        Departament = element.Split("||")[3]
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Program zglosil wyjatek \"{ex.Message}\" dla {element}");
                }
            }
            Console.WriteLine("Wszyscy pracownicy:");
            foreach (Pracownik pracownik in pracownicy)
            {
                Console.WriteLine($"{pracownik.Login}|{pracownik.Nazwisko}|{pracownik.Haslo}|{ pracownik.Departament}");
            }
            Console.WriteLine();
            Console.WriteLine("Podaj departament zeby sprawdzic dane pracownikow:");
            string dep = Console.ReadLine();
            Console.WriteLine($"Pracownicy w dziale {dep}:");
            if (pracownicy.Exists((p) => { return p.Departament == dep; }))
            {
                IEnumerable<Pracownik> enumerable = pracownicy.Where((p) => p.Departament == dep);
                List<Pracownik> pracownicyDoWyswietlenia = enumerable.ToList();
                
                foreach(Pracownik p in pracownicyDoWyswietlenia)
                Console.WriteLine($"{p.Login}|{ p.Nazwisko}|{p.Haslo}|{p.Departament}");
            } else
                Console.WriteLine($"W dziale {dep} nie znaleziono pracownikow");

            Console.WriteLine();
            Console.WriteLine("Czy chcesz zresetowac haslo dla aktywnego użytkownika?");
            string losowehaslo = (Console.ReadLine()).ToLower();
            if (losowehaslo == "tak")
            {
                Console.WriteLine("Podaj login aktywnego użytkownika żeby zresetowac hasło:");
                string podanylogin = Console.ReadLine();

               
                Pracownik pracownikdozmianyhasla = pracownicy.Find((p) => { return p.Login == podanylogin; });

                if (pracownikdozmianyhasla == null)
                {
                    Console.Out.WriteLine("Nie znaleziono uzytkownika o podanym loginie");
                } else
                {
                    pracownikdozmianyhasla.UstawHaslo(pracownicyLogika.WygenerujHaslo());
                    Console.WriteLine($"Nowe haslo to:" + pracownikdozmianyhasla.Haslo);
                }
            }
            else
                Console.WriteLine("Nie zdecydowales sie na zmiane hasla :( ");

            Console.Out.WriteLine("Wszyscy pracownicy posortowani to: ");
            var pracownicyAlfabetycznie = pracownicyLogika.SortujAlfabetycznie(pracownicy);

            foreach(Pracownik p in pracownicyAlfabetycznie)
            {
                Console.WriteLine($"{p.Login}|{ p.Nazwisko}|{p.Haslo}|{p.Departament}");
            }
        }
        static string[] InicjujPracownikow()
        {
            string[] Baza_pracownikow = new string[]
            {
                "login1||Jan Janowski||5tg5fr534||HR",
                "login2||Adam Adamowski||54rt345||HR",
                "login3||Piotr Piotrowski||gdf54354df||IT",
                "login4||Maciej Maciejowski||54hfghfg3df||IT",
            };
            return Baza_pracownikow;
        }
    }
}
