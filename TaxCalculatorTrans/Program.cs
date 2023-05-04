using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menuStart = new Menu("Kalkulator wynagrodzeń");
            Menu menuUmowaOPracę = new Menu("Kalkulator umowy o pracę");
            Menu menuUmowaZlecenie = new Menu("Kalkulator umowy zlecenia");
            
            menuStart.PozycjeMenu = new Dictionary<string, Action<decimal?>>
            {
                { "Umowa o pracę", x=>menuUmowaOPracę.WyswietlajMenu() },
                { "Umowa zlecenie", x=>menuUmowaZlecenie.WyswietlajMenu() },
            };

            menuUmowaOPracę.PozycjeMenu = new Dictionary<string, Action<decimal?>>
            {
                {"Wylicz wynagrodzenie do umowy o pracę", x=>PokazUmowe(new UmowaOPrace(),"UMOWA O  PRACĘ")},
                {"Powrót do menu głównego", x=>menuStart.WyswietlajMenu() },
            };

            menuUmowaZlecenie.PozycjeMenu = new Dictionary<string, Action<decimal?>>
            {
                {"Wylicz qwynagrodzenie do umowy zlecenia", x=>PokazUmowe(new UmowaZlecenie(), "UMOWA ZLECENIE") },
                {"Powrót do menu głównego", x=>menuStart.WyswietlajMenu() },
            };

            menuStart.WyswietlajMenu();
        }

        public static void PokazUmowe(Umowa umowa, string rodzajUmowy)
        {
            decimal kwota = 0;
            while (kwota <= 0)
            {
                Console.Clear();
                Console.WriteLine(rodzajUmowy);
                Console.Write("Podaj kwotę umowy: ");
                Decimal.TryParse(Console.ReadLine().Replace(",", "."), out kwota);
                if (kwota <= 0)
                {
                    Console.WriteLine("Podaj kwotę >=0");
                }
            }

            umowa.podstawa = kwota;
            KalkulatorWynagrodzenia kalkulatorWynagrodzenia = new KalkulatorWynagrodzenia(umowa);
            kalkulatorWynagrodzenia.widokWyliczenia = new WidokWynagrodzeniaNaEkranie();
            kalkulatorWynagrodzenia.WyliczWynagrodzenie();
            Console.Clear();
            Console.WriteLine(rodzajUmowy);
            kalkulatorWynagrodzenia.WyświetlWynagrodzenie();
        }
    }
}





