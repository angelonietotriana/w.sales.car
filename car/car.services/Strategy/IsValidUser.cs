using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;

namespace w.sale.car.services.Strategy
{
    public class IsValidUser : IValidReserve
    {
        private readonly IRepository<User> _repositoryUser;
        private readonly int _idUser;
        public IsValidUser(IRepository<User> repositoryUser,
                              int clientId)
        {
            this._repositoryUser = repositoryUser;
            this._idUser = clientId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Valid()
        {
            _ = await _repositoryUser.GetByIdAsync(_idUser) ?? throw new NotFoundClientException(NotFoundClientException.Message);
        }
    }
}
