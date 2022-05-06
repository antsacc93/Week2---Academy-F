using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale
{
    public class Publisher
    {
        public delegate void Notify(IEnumerable<Expense> spese);

        //Evento
        public event Notify OnPublish;

        public void Publish(IEnumerable<Expense> spese)
        {
            if (OnPublish != null)
            {
                OnPublish(spese);
            }
        }
    }
}
