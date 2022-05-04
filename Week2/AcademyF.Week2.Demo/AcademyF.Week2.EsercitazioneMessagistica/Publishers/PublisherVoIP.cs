using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AcademyF.Week2.EsercitazioneMessagistica.Publishers.IPublisher;

namespace AcademyF.Week2.EsercitazioneMessagistica.Publishers
{
    public class PublisherVoIP : IPublisher
    {
        public string PublisherName { get; set; }

        public event Notify OnPublish;

        public PublisherVoIP(string name)
        {
            PublisherName = name;
        }

        public void Publish(string sender)
        {
            if(OnPublish != null)
            {
                Notification notifica = new Notification("Nuova notifica da ", sender, DateTime.Now);
                OnPublish(this, notifica);
            }
        }
    }
}
