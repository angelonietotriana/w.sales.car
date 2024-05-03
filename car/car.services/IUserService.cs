using w.sale.car.db.Dtos;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public interface IUserService
    {
        Task<int> Create(UserInDto userInDto);
        Task Dalete(int idUser);
        Task Update(UserInDto userInDto);
        List<User?> SearchByParams(UserFindDto userFindDto);
    }
}
