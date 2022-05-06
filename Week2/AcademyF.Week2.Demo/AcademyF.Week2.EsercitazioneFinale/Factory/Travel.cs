using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Factory
{
    public class Travel : ICategory
    {
        public string Name { get; set; } = "Travel";

        public double GetRefund(Expense expense)
        {
            return expense.Amount + 50;
        }
    }
}
