using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class Umowa
    {
        public decimal podstawa;
        public virtual List<Potracenie> ListaPotracen { get; set; }
    }
}
