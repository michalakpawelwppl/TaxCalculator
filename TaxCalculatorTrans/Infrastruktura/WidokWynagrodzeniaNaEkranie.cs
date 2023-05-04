using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorTrans
{
    public class WidokWynagrodzeniaNaEkranie : WidokWyliczenia
    {
        public override void PokażWynagrodzenie(Wynagrodzenie wynagrodzenie)
        {
            string result = $"Wynagrodzenie brutto: {String.Format("{0,00:#,###.00}", wynagrodzenie.Podstawa)}";

            foreach (var potracenie in wynagrodzenie.Potracenia)
            {
                result += $"{TrescSkładnikaJeśliIstnieje(wynagrodzenie, potracenie.Nazwa)}\n";
            }
            var wynagrodzenieNetto = wynagrodzenie.Podstawa - wynagrodzenie.Potracenia.Sum(p => p.Wartosc);
            result += $"Pracownik otrzyma wynagrodzenie netto w wysokości: {String.Format("{0,00:#,###.00}",wynagrodzenieNetto)}";

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
