using AcademyF.Week2.EsercitazioneFinale.Entities;


namespace AcademyF.Week2.EsercitazioneFinale.Factory
{
    public class Food : ICategory
    {
        public string Name { get; set; } = "Food";

        public double GetRefund(Expense expense)
        {
            return expense.Amount * 0.70;
        }

        
    }
}
