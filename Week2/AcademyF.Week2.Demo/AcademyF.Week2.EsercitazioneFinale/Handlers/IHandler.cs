using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Handlers
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Refund Handle(Expense expense);
    }
}
