using w.sale.car.db.Dtos;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public interface ICarService
    {
        Task<int> Create(CarInDto carInDto);
        Task Delete(int idCar);
        Task Update(CarInDto carInDto);
        Task<List<Car>> SearchByParams(CarFindDto carFindDto);
    }
}
