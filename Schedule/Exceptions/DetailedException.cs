namespace Schedule.Exceptions
{
    public class DetailedException : BadHttpRequestException
    {
        public object? Details { get; set; } = null;
        public DetailedException(string message) : base(message) { }
        public DetailedException(string message, int statusCode) : base(message, statusCode) { }
        public DetailedException(string message, int statusCode, object details) : base(message, statusCode) 
        {
            Details = details;
        }
    }
}
