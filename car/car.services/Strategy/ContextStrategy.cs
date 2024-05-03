namespace w.sale.car.services.Strategy
{
    public class ContextStrategy
    {
        private readonly IValidReserve validReserva;

        public ContextStrategy(IValidReserve strategy)
        {
            this.validReserva = strategy;   
        }

        public async Task ExecuteStrategy()
        {
            await validReserva.Valid();
        }
    }
}
