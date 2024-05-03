namespace w.sale.car.exceptions
{
    public  class NotFoundClientException : Exception
    {
        static readonly string message = "El cliente no fue encontrado";
        public NotFoundClientException()
        {

        }

        public NotFoundClientException(string message) : base(message) { }

        public NotFoundClientException(string message, Exception inner)
            : base(message, inner) { }

        public static string Message => message;
    }
}
