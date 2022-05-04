using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Demo.Eventi.Pub_Sub
{
    public class Publisher
    {
        public string PublisherName { get; set; }

        public Publisher(string name)
        {
            PublisherName = name;
        }

        //Delegato da utilizzare nell'evento
        public delegate void Notify(Publisher p, Notification notification);

        //Evento
        public event Notify OnPublish;

        //Metodo che effettivamente scatena l'evento
        public void Publish()
        {
            if(OnPublish != null)
            {
                Notification notifica = new Notification("New notification arrived from ", DateTime.Now); 
                OnPublish(this, notifica);
            }
        }

        
    }
}
