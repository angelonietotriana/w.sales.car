namespace w.sale.car.exceptions
{
    [Serializable]
    public class NotFoundReserveException : Exception
    {
        static readonly string message = "La reserva no fue encontrada";

        
        public NotFoundReserveException() 
        {

        }

        public NotFoundReserveException(string message) : base(message) { }

        public NotFoundReserveException(string message, Exception inner)
            : base(message, inner) { }

        public static string Message => message;
    }
}
