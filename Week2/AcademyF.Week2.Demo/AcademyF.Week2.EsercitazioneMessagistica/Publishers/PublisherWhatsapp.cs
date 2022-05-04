using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AcademyF.Week2.EsercitazioneMessagistica.Publishers.IPublisher;

namespace AcademyF.Week2.EsercitazioneMessagistica.Publishers
{
    public class PublisherWhatsapp : IPublisher
    {
        public string PublisherName { get; set; }
        public bool IsGroup { get; set; }

        public PublisherWhatsapp(string name, bool isGroup)
        {
            PublisherName = name;
            IsGroup = isGroup;
        }

        public event Notify OnPublish;

        public void Publish(string sender)
        {
            if(OnPublish != null)
            {
                Notification notifica = new Notification("Nuovo messaggio da ", sender, DateTime.Now);
                OnPublish(this, notifica, "", IsGroup);
            }
        }

        public override string ToString()
        {
            if (IsGroup)
                return "Da un gruppo";
            else
                return "Da utente singolo";
        }
    }
}
