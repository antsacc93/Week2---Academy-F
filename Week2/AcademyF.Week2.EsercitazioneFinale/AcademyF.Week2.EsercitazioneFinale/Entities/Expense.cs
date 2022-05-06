using AcademyF.Week2.EsercitazioneFinale.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Entities
{
    public class Expense
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public ICategory Category { get; set; }

        //LOAD FROM FILE
        public static IEnumerable<Expense> LoadExpenseFromFile(string file)
        {
            List<Expense> spese = new List<Expense>();
            CategoryFactory factory = new CategoryFactory();
            //codice di lettura da file
            using(StreamReader sr = File.OpenText($""))
            {
                //leggo riga per riga il file
                string line = sr.ReadLine();
                while(line != null)
                {
                    string[] expenseData = line.Split(';');
                    Expense expense = new Expense()
                    {
                        Date = DateTime.Parse(expenseData[0]),
                        Description = expenseData[1],
                        Amount = double.Parse(expenseData[2]),
                        Category = factory.GetCategory(expenseData[3])
                    };
                    spese.Add(expense);
                    line = sr.ReadLine();
                }
            }

            return spese;
        }
    }
}
