using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;

namespace w.sale.car.services.Strategy
{
    public class IsValidLocation : IValidReserve
    {
        private readonly IRepository<Location> _repositoryLocation;
        private readonly int _idLocation;
        public IsValidLocation(IRepository<Location> repositoryLocation,
                                int idLocation)
        {
            this._repositoryLocation = repositoryLocation;
            this._idLocation = idLocation;
        }

        public async Task Valid()
        {
            _ = await _repositoryLocation.GetByIdAsync(this._idLocation) ?? throw new NotFoundLocationException(NotFoundLocationException.Mensaje);
        }
    }
}
