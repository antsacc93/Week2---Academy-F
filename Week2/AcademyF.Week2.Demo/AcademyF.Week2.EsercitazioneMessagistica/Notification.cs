namespace AcademyF.Week2.EsercitazioneMessagistica
{
    public class Notification
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }

        public Notification(string message, string sender, DateTime date)
        {
            Message = message;
            Sender = sender;
            Date = date;
        }
    }
}