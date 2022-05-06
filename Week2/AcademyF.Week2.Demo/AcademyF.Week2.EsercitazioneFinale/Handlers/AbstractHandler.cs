using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Handlers
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _next;

        public virtual Refund Handle(Expense expense)
        {
            if (_next != null)
            {
                return _next.Handle(expense);
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            _next = handler;
            return handler;
        }
    }
}
