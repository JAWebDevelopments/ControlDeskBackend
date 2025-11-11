namespace ControlDesk.Domain.Exceptions
{
    public class TicketException : Exception
    {
        public TicketException() { }

        public TicketException(string message) : base(message) { }

        public TicketException(string message, Exception innerException) : base(message, innerException) { }
    }
}
