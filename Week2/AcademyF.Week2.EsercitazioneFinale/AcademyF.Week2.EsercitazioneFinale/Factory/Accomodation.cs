using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Factory
{
    public class Accomodation : ICategory
    {
        public string Name { get; set; } = "Alloggio";

        public double GetRefundAmount(Expense expense)
        {
            return expense.Amount;
        }
    }
}
