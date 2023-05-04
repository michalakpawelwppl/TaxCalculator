using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class KalkulatorWynagrodzenia
    {
        public IWidokWyliczenia widokWyliczenia;

        public Umowa umowa { get; set; }

        public Wynagrodzenie Wynagrodzenie
        {
            get
            {
                if (umowa != null)
                {
                    return WyliczWynagrodzenie();
                }
                else return null;
            }
        }

        public KalkulatorWynagrodzenia(Umowa umowa)
        {
            this.umowa = umowa;
        }

        public Wynagrodzenie WyliczWynagrodzenie()
        {
            Wynagrodzenie wynagrodzenie = new Wynagrodzenie();
            wynagrodzenie.Podstawa = umowa.podstawa;

            foreach (var potracenie in umowa.ListaPotracen.Where(p => p.PodstawaNaliczenia == NazwaSkladnika.brutto))
            {
                potracenie.Wartosc = potracenie.WyliczeniePotrącenia.Invoke(umowa.podstawa);
                wynagrodzenie.Potracenia.Add(potracenie);
            }

            var sumaSkładekSpołecznych = umowa.ListaPotracen.First(p => p.Nazwa == NazwaSkladnika.składkaEmerytalna).Wartosc
                + umowa.ListaPotracen.First(p => p.Nazwa == NazwaSkladnika.składkaRentowa).Wartosc
                + umowa.ListaPotracen.First(p => p.Nazwa == NazwaSkladnika.składkaChorobowa).Wartosc;

            var małeBrutto = umowa.podstawa - sumaSkładekSpołecznych;

            foreach (var potracenie in umowa.ListaPotracen.Where(p => p.PodstawaNaliczenia == NazwaSkladnika.małeBrutto))
            {
                potracenie.Wartosc = potracenie.WyliczeniePotrącenia.Invoke(małeBrutto);
                wynagrodzenie.Potracenia.Add(potracenie);
            }

            return wynagrodzenie;
        }

        public void WyświetlWynagrodzenie()
        {
           widokWyliczenia.PokażWynagrodzenie(Wynagrodzenie);
        }
    }
}