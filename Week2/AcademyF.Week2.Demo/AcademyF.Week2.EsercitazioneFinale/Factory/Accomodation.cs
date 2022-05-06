using AcademyF.Week2.EsercitazioneFinale.Entities;

namespace AcademyF.Week2.EsercitazioneFinale.Factory
{
    public class Accomodation : ICategory
    {
        public string Name { get; set; } = "Accomodation";

        public double GetRefund(Expense expense)
        {
            return expense.Amount;
        }
    }
}
