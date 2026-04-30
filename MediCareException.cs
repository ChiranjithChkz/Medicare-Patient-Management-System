namespace Medicare
{
    public class MediCareException : Exception
    {
        public MediCareException() : base("A MediCare+ system error occurred.") { }

        public MediCareException(string message) : base(message) { }

        public MediCareException(string message, Exception innerException) : base(message, innerException) { }
    }
}