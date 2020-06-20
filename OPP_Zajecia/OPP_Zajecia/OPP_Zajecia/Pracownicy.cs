using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OPP_Zajecia
{
    public class Pracownicy : List<Pracownik>
    {
        
        public IOrderedEnumerable<Pracownik> SortujAlfabetycznie(List<Pracownik> pracownicy)
        {
            var myLinqQuery = from pracownik in pracownicy
                              orderby pracownik.Nazwisko
                              select pracownik;

            return myLinqQuery;
        }

        public String WygenerujHaslo()
        {
            return RandomString(7);
        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
