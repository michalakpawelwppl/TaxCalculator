using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class UmowaOPrace : Umowa
    {

        public static List<SkładnikParametr> SkładnikiParametry = new List<SkładnikParametr>
        {
            new SkładnikParametr(){Nazwa = NazwaSkladnika.kosztyUzyskaniaPrzychodów, Wartosc = 111.25M }
        };

        private List<Potracenie> listaPotracen = new List<Potracenie>
            {
                new Potracenie() { Nazwa = NazwaSkladnika.składkaEmerytalna, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 9.76 / 100) },
                new Potracenie() { Nazwa = NazwaSkladnika.składkaRentowa, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 1.5 / 100) },
                new Potracenie() { Nazwa = NazwaSkladnika.składkaChorobowa, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 2.45 / 100) },
                new Potracenie() { Nazwa = NazwaSkladnika.składkaZdrowotna, PodstawaNaliczenia = NazwaSkladnika.małeBrutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 9 / 100) },
                new Potracenie() { Nazwa = NazwaSkladnika.zaliczkaNaPodatek, PodstawaNaliczenia = NazwaSkladnika.małeBrutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)(podstawa - SkładnikiParametry.FirstOrDefault(s=>s.Nazwa==NazwaSkladnika.kosztyUzyskaniaPrzychodów).Wartosc) * 18 / 100 - (float)podstawa * 7.75 / 100)},
            };

        public override List<Potracenie> ListaPotracen { get { return listaPotracen; } set { listaPotracen = value; } }
    }
}
