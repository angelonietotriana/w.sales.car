using w.sale.car.db.Dtos;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public interface ILocationService
    {
        Task<int> Create(LocationInDto locationInDto);
        Task Delete(int idLocation);
        Task Update(LocationInDto locationInDto);
        Task<List<Location>> SearchByParams(LocationFindDto locationInDto);
    }
}
