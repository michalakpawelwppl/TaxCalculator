using System.Collections.Generic;
using System.Linq;

namespace TaxCalculatorTrans
{
    public class Wynagrodzenie
    {
        private decimal podstawa;
        public decimal Podstawa
        {
            get
            {
                if (Naliczenia.Any())
                {
                    return Naliczenia.Sum(n => n.Wartosc);
                }
                return podstawa;
            }
            set
            {
                podstawa = value;
            }
        }
       
        public List<Naliczenie> Naliczenia { get; set; } = new List<Naliczenie> { };
        public List<Potracenie> Potracenia { get; set; } = new List<Potracenie> { };
    }
}
