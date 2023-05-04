using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class SkładnikParametr : SkładnikWynagrodzenia
    {
        public Func<decimal, decimal> WyliczenieParametru { get; set; }
    }
}
