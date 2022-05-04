using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Demo.Eventi.Pub_Sub
{
    public class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        //Metodi di subscribe/unsubscribe
        public void Subscribe(Publisher p)
        {
            //registrazione all'evento di notifica
            p.OnPublish += OnNotificationReceived;
        }

        public void UnSubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        //Metodo che gestice la ricezione della notifica
        public void OnNotificationReceived(Publisher p, Notification n)
        {
            //L'evento scatena una stampa su console
            Console.WriteLine($"Ciao, {SubscriberName}, {n.Message} pubblicato da {p.PublisherName} " +
                $"alle ore {n.DateReceived}");
        }
    }
}
