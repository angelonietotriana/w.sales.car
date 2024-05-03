using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;

namespace w.sale.car.services.Strategy
{
    public class IsValidCar : IValidReserve
    {
        
        private readonly IRepository<Car> _repositoryCar;
        private readonly int _idCar;

        public IsValidCar(IRepository<Car> repositoryVehiculo,
                              int idVehiculo)
        {
            this._repositoryCar = repositoryVehiculo;
            this._idCar = idVehiculo;
        }


        public async Task Valid()
        {
          _ = await _repositoryCar.GetByIdAsync(_idCar) ?? throw new NotFoundCarException(NotFoundCarException.Message);
        }
    }
}
