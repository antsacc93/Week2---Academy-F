using AcademyF.Week2.EsercitazioneFinale.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Entities
{
    public class Refund
    {
        public Expense Expense { get; set; }
        public double RefundAmount { get; set; }
        public bool Approved { get; set; }
        public string ApprovationLevel { get; set; }

        //METODO DI ELABORAZIONE DEI RIMBORSI
        public static List<Refund> ElaborazioneRimborsi(IEnumerable<Expense> spese)
        {
            List<Refund> rimborsi = new List<Refund>();

            var managerHandler = new ManagerHandler();
            var opHandler = new OPMHandler();
            var ceoHandler = new CEOHandler();

            managerHandler.SetNext(opHandler).SetNext(ceoHandler);

            foreach (var expense in spese)
            {
                var refund = managerHandler.Handle(expense);
                if (refund == null)
                {
                    refund = new Refund()
                    {
                        Expense = expense,
                        Approved = false
                    };
                }
                rimborsi.Add(refund);
            }

            return rimborsi;
        }

        //STAMPA
        public static void SaveToFile(string fileName, IEnumerable<Refund> refunds)
        {
            try
            {
                using (StreamWriter writer = File.CreateText($@"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1\{fileName}.txt"))
                {
                    foreach (var refund in refunds)
                    {
                        string dati = $"{refund.Expense.Date.ToShortDateString()};" +
                            $"{refund.Expense.Category.Name};{refund.Expense.Description};";
                        if (refund.Approved)
                        {
                            dati += $"APPROVATA;{refund.ApprovationLevel};{refund.RefundAmount}";
                        }
                        else
                        {
                            dati += $"RESPINTA;-;-";
                        }
                        writer.WriteLine(dati);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
