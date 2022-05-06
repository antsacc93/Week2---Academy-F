using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Handler
{
    public class ManagerHandler : AbstractHandler
    {
        public override Refund Handle(Expense expense)
        {
            if(expense.Amount > 0 && expense.Amount <= 400)
            {
                return new Refund()
                {
                    Expense = expense,
                    ApprovationLevel = "Manager",
                    IsApproved = true,
                    RefundAmount = expense.Category.GetRefundAmount(expense)
                };
            }
            else
            {
                return base.Handle(expense);
            }
            
        }
    }
}
