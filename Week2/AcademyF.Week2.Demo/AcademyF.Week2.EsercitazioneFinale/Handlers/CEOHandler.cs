using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Handlers
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
                    Approved = true,
                    ApprovationLevel = "CEO",
                    RefundAmount = expense.Category.GetRefund(expense)
                };
            }
            return base.Handle(expense);
        }
    }
}
