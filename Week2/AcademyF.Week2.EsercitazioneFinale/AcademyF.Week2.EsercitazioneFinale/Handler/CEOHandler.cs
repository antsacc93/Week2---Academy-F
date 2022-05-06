using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Handler
{
    public class CEOHandler : AbstractHandler
    {
        public override Refund Handle(Expense expense)
        {
            if (expense.Amount > 1000 && expense.Amount <= 2500)
            {
                return new Refund()
                {
                    Expense = expense,
                    ApprovationLevel = "CEO",
                    IsApproved = true,
                    RefundAmount = 0.0
                };
            }
            else
            {
                return base.Handle(expense);
            }
        }
    }
}
