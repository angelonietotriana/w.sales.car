namespace w.sale.car.exceptions
{
    public  class NotFoundLocationException : Exception
    {
        static readonly string message = "La Ubicación no fue encontrada";

        public NotFoundLocationException()
        {

        }

        public NotFoundLocationException(string message) : base(message) { }

        public NotFoundLocationException(string message, Exception inner)
            : base(message, inner) { }

        public static string Mensaje => message;
    }
}
