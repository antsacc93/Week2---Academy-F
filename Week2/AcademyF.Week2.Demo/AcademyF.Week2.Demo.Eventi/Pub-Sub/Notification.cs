namespace AcademyF.Week2.Demo.Eventi.Pub_Sub
{
    public class Notification
    {
        public string Message { get; set; }
        public DateTime DateReceived { get; set; }

        public Notification(string message, DateTime date)
        {
            Message = message;
            DateReceived = date;
        }
    }
}