using AcademyF.Week2.EsercitazioneFinale.Entities;


namespace AcademyF.Week2.EsercitazioneFinale.Handlers
{
    public class ManagerHandler : AbstractHandler
    {
        public override Refund Handle(Expense expense)
        {
            if (expense.Amount > 0 && expense.Amount <= 400)
            {
                return new Refund()
                {
                    Expense = expense,
                    Approved = true,
                    ApprovationLevel = "Manager",
                    RefundAmount = expense.Category.GetRefund(expense)
                };
            }
            else
            {
                return base.Handle(expense);
            }
        }
    }
}
