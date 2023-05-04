using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public abstract class WidokWyliczenia  : IWidokWyliczenia
    {
        private Dictionary<NazwaSkladnika, string> wyswetlanaNazwaSkładnika = new Dictionary<NazwaSkladnika, string>
        {
            { NazwaSkladnika.brutto, "Wynagrodzenie brutto" },
            { NazwaSkladnika.składkaEmerytalna, "Składka na ubezpieczenie emerytalne" },
            { NazwaSkladnika.zaliczkaNaPodatek, "Zaliczka na podatek" },
            { NazwaSkladnika.składkaZdrowotnaOdliczalna, "Składkazdrowotna odliczana" },
            { NazwaSkladnika.składkaZdrowotna, "Składka zdrowotna" },
            { NazwaSkladnika.składkaRentowa, "Składka na ubezpieczenie rentowe" },
            { NazwaSkladnika.składkaChorobowa, "Składka na ubezpieczenie chorobowe" },
            { NazwaSkladnika.małeBrutto, "Małe brutto" }
        };

        protected string TrescSkładnikaJeśliIstnieje(Wynagrodzenie wynagrodzenie, NazwaSkladnika nazwaSkładnika)
        {
            var potracanie = wynagrodzenie.Potracenia.FirstOrDefault(p => p.Nazwa == nazwaSkładnika);
            if (potracanie != null)
            {
                return $"{WyświetlanaNazwaSkładnika(nazwaSkładnika)}: {String.Format("{0,00:#,###.00}", potracanie.Wartosc)}";
            }
            else return string.Empty;
        }

        public string WyświetlanaNazwaSkładnika(NazwaSkladnika składnik)
        {
            string składnikNazwaDoWyswietlania;
            wyswetlanaNazwaSkładnika.TryGetValue(składnik, out składnikNazwaDoWyswietlania);
            if (składnikNazwaDoWyswietlania != null)
            {
                return składnikNazwaDoWyswietlania;
            }

            return składnik.ToString();
        }

        public abstract void PokażWynagrodzenie(Wynagrodzenie wynagrodzenie);
    }
}
