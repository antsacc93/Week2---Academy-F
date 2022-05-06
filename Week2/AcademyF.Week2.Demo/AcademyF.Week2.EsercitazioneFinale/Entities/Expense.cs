using AcademyF.Week2.EsercitazioneFinale.Factory;
using System;
using System.Collections.Generic;
using System.IO;
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

        //LOAD
        public static IEnumerable<Expense> GetExpenses(string fileName)
        {
            List<Expense> spese = new List<Expense>();
            CategoryFactory factory = new CategoryFactory();
            try
            {
                using (StreamReader reader = File.OpenText($@"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1\{fileName}.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] datiExpense = line.Split(";");
                        Expense expense = new Expense()
                        {
                            Date = DateTime.Parse(datiExpense[0]),
                            Category = factory.GetCategory(datiExpense[1]),
                            Description = datiExpense[2],
                            Amount = double.Parse(datiExpense[3])
                        };
                        spese.Add(expense);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return spese;
        }
    }
}
