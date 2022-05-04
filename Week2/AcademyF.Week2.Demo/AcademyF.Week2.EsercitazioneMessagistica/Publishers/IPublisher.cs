using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneMessagistica.Publishers
{
    public interface IPublisher
    {
        public string PublisherName { get; set; }

        //Delegato comune a tutti
        public delegate void Notify(IPublisher p, Notification notification,
            string provider = "", bool isGroup = false);

        //evento di pubblicazione
        public event Notify OnPublish;

        public void Publish(string sender);
    }
}
