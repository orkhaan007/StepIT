namespace Notification
{
    public class Notification
    {
        public Guid id { get; }
        public string message { get; }
        public DateTime dateTime { get; }

        public Notification(string message)
        {
            id = Guid.NewGuid();
            message = message;
            dateTime = DateTime.Now;
        }
    }
}