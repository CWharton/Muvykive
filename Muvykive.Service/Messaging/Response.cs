namespace Muvykive.Service.Messaging
{
    public abstract class Response
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}