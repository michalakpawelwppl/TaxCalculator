using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class UmowaZlecenie : Umowa
    {
        public static List<SkładnikParametr> SkładnikiParametry = new List<SkładnikParametr>
        {
            new SkładnikParametr(){Nazwa = NazwaSkladnika.kosztyUzyskaniaPrzychodów, WyliczenieParametru = (podstawa)=>(decimal)((float)podstawa*0.2) }
        };

        private List<Potracenie> listaPotracen = new List<Potracenie>
        {
            new Potracenie() { Nazwa = NazwaSkladnika.składkaEmerytalna, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 9.76 / 100) },
            new Potracenie() { Nazwa = NazwaSkladnika.składkaRentowa, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 1.5 / 100) },
            new Potracenie() { Nazwa = NazwaSkladnika.składkaChorobowa, PodstawaNaliczenia = NazwaSkladnika.brutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 2.45 / 100) },
            new Potracenie() { Nazwa = NazwaSkladnika.składkaZdrowotna, PodstawaNaliczenia = NazwaSkladnika.małeBrutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)podstawa * 9 / 100) },
            new Potracenie() { Nazwa = NazwaSkladnika.zaliczkaNaPodatek, PodstawaNaliczenia = NazwaSkladnika.małeBrutto, WyliczeniePotrącenia = (podstawa) => (decimal)((float)(((float)podstawa - (float)SkładnikiParametry.FirstOrDefault(s=>s.Nazwa==NazwaSkladnika.kosztyUzyskaniaPrzychodów).WyliczenieParametru(podstawa)) * 18 / 100 - (float)podstawa * 7.75 / 100))},
        };

        public override List<Potracenie> ListaPotracen { get { return listaPotracen; } set { listaPotracen = value; } }
    }
}
