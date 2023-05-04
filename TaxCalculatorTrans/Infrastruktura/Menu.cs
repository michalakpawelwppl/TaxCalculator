using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class Menu
    {
        private KeyValuePair<string, Action <decimal?>> pozycjaMenuWyjscie = new KeyValuePair<string, Action<decimal?>>("Wyjście z programu", x => Environment.Exit(0));

        public string Nagłówek { get; set; }

        private Dictionary<string, Action<decimal?>> pozycjeMenu;
        public Dictionary<string, Action<decimal?>> PozycjeMenu
        {
            get
            {
                if (pozycjeMenu!=null && !pozycjeMenu.ContainsKey(pozycjaMenuWyjscie.Key))
                {
                    pozycjeMenu.Add(pozycjaMenuWyjscie.Key, pozycjaMenuWyjscie.Value);
                }
                return pozycjeMenu;
            }
            set
            {
                pozycjeMenu = value;
            }

        }

        private int? aktywnaPozycjaMenu;
        public int AktywnaPozycjaManu
        {
            get
            {
                if (aktywnaPozycjaMenu == null)
                {
                    aktywnaPozycjaMenu = 0;
                    return (int)aktywnaPozycjaMenu;
                }
                else return aktywnaPozycjaMenu.Value;
            }
            set
            {
                aktywnaPozycjaMenu = value;
            }
        }

        public Menu(string nagłówek)
        {
            PozycjeMenu = new Dictionary<string, Action<decimal?>>();
            Nagłówek = nagłówek;
        }
        public Menu()
        {
            PozycjeMenu = new Dictionary<string, Action<decimal?>>();
            Nagłówek = string.Empty;
        }
        public Menu(Dictionary<string, Action<decimal?>> pozycjeMenu)
        {
            this.pozycjeMenu = pozycjeMenu;
        }

        public void WyswietlajMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                PokazMenu();
                WybieranieOpcji();
                UruchomOpcje();
            }
        }

        private void UruchomOpcje()
        {
            PozycjeMenu.ElementAt(AktywnaPozycjaManu).Value.Invoke(null);
        }

        private void WybieranieOpcji()
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    AktywnaPozycjaManu = (AktywnaPozycjaManu > 0) ? AktywnaPozycjaManu -1 : PozycjeMenu.Count()-1;
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    AktywnaPozycjaManu = (AktywnaPozycjaManu + 1) % PozycjeMenu.Count();
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    AktywnaPozycjaManu = PozycjeMenu.Count() - 1;
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                    break;

            }
            while (true);
        }

        public void PokazMenu()
        {
            Console.Clear();
            Console.WriteLine(Nagłówek);

            foreach (var pozycja in PozycjeMenu)
            {
                if (PozycjeMenu.ElementAt(AktywnaPozycjaManu).Equals(pozycja))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0,-35}", pozycja.Key);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(pozycja.Key);
                }
            }
        }
    }
}
