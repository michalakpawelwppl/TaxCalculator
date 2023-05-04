using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class Potracenie : SkładnikWynagrodzenia
    {
        public NazwaSkladnika PodstawaNaliczenia { get; set; }
        public Func<decimal, decimal> WyliczeniePotrącenia { get; set; }
    }
}
