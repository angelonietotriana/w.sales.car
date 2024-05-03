namespace w.sale.car.exceptions
{
    public  class NotFoundCarException : Exception
    {
        static readonly string message = "El vehículo no fue encontrado";
        public NotFoundCarException()
        {

        }
        public NotFoundCarException(string message) : base(message) { }

        public NotFoundCarException(string message, Exception inner)
            : base(message, inner) { }

        public static string Message => message;
    }
}
