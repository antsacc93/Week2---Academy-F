using AcademyF.Week2.EsercitazioneFinale.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Entities
{
    public class Refund
    {
        public Expense Expense { get; set; }
        public string ApprovationLevel { get; set; }
        public bool IsApproved { get; set; }
        public double RefundAmount { get; set; }

        
        public static IEnumerable<Refund> GestioneRimborsi(IEnumerable<Expense> spese)
        {
            List<Refund> rimborsi = new List<Refund>();

            //creo la chain
            var managerHandler = new ManagerHandler();
            var opHandler = new OPHandler();
            var ceoHandler = new CEOHandler();

            managerHandler.SetNext(opHandler).SetNext(ceoHandler);

            foreach (var spesa in spese)
            {
                var refund = managerHandler.Handle(spesa);
                if(refund == null)
                {
                    refund = new Refund()
                    {
                        Expense = spesa,
                        IsApproved = false
                    };
                }
                rimborsi.Add(refund);
            }
            return rimborsi;
        }

        //metodo che salva su file le spese rimborsate
        public static void SalvaRimborsoSuFile(string fileName, IEnumerable<Refund> refunds)
        {
            using(StreamWriter writer = File.CreateText(""))
            {
                foreach (var refund in refunds)
                {
                    string line = $"{refund.Expense.Date.ToShortDateString()};" +
                        $"{refund.Expense.Category.Name};{refund.Expense.Description};";
                    if (refund.IsApproved)
                        line += $"APPROVATA;{refund.ApprovationLevel};{refund.RefundAmount}";
                    else
                        line += "RESPINTA;-;-";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
