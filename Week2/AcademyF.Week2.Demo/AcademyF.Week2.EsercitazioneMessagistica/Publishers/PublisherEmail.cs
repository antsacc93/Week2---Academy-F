using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AcademyF.Week2.EsercitazioneMessagistica.Publishers.IPublisher;

namespace AcademyF.Week2.EsercitazioneMessagistica.Publishers
{
    public class PublisherEmail : IPublisher
    {
        public string Provider { get; set; }
        public string PublisherName { get; set; }

        public PublisherEmail(string provider, string name)
        {
            Provider = provider;
            PublisherName = name;
        }

        public event Notify OnPublish;

        public void Publish(string sender)
        {
            if(OnPublish != null)
            {
                Notification notificationObj = new Notification("New email from " + sender, sender, DateTime.Now);
                OnPublish(this, notificationObj, Provider);
            }
        }

        public override string ToString()
        {
            return $"\n Provider: {Provider}";
        }
    }
}
