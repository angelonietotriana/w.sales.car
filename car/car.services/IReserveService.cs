using w.sale.car.db.Dtos;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public interface IReserveService
    {
        Task<int> Create(ReserveInDto reserveInDto);
        Task Delete(int idReserve);
        Task Update(ReserveInDto reserveInDto);
        Task<List<Reserve>> SearchByParams(ReserveFindDto reserveFindDto);
    }
}
