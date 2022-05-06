using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale
{
    public class HandleFile
    {
        public void Subscribe(Publisher p)
        {
            p.OnPublish += HandleNewFile;
        }

        public void HandleNewFile(IEnumerable<Expense> spese)
        {
            
            //ELABORAZIONE RIMBORSI
            Console.WriteLine("Sto elaborando i rimborsi ... ");

            var rimborsi = Refund.ElaborazioneRimborsi(spese);

            //SCRITTURA SU FILE
            Refund.SaveToFile("spese_elaborate", rimborsi);

            Console.WriteLine("Fine elaborazione");
        }
    }
}
