using AcademyF.Week2.EsercitazioneMessagistica.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneMessagistica
{
    public class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        public void Subscribe(IPublisher p)
        {
            p.OnPublish += OnNotificationReceived;
        }

        public void OnNotificationReceived(IPublisher p, Notification n, string provider, bool isGroup)
        {
            Console.WriteLine($"Ciao, {SubscriberName}, {n.Message} alle ore {n.Date} {p.ToString()}");
        }
    }
}
