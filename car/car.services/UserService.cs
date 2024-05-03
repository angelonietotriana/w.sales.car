using LinqKit;
using Microsoft.EntityFrameworkCore;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContex,
                               IRepository<User> userRepository)
        {
            this.appDbContext = appDbContex;
            this.userRepository = userRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInDto"></param>
        /// <returns></returns>
        public async Task<int> Create(UserInDto userInDto)
        {
            User user = new()
            {
                Document = userInDto.Document,
                State = userInDto.State,
                PaymentType = userInDto.PaymentType,
                DocumentType = userInDto.DocumentType,
                Phone = userInDto.Phone,
                AmountApproved = userInDto.AmountApproved,
                Type = userInDto.Type
            };

            userRepository.Insert(user);
            await userRepository.SaveChangesAsync();
            return 1;
        }


        public async Task Update(UserInDto userInDto)
        {
            User? userToUpdate = await userRepository.GetByIdAsync(userInDto.IdUser);


            if (userToUpdate != null)
            {
                userToUpdate.DocumentType = !string.IsNullOrEmpty(userInDto.DocumentType) ? userInDto.DocumentType : userToUpdate.DocumentType;
                userToUpdate.Document = userInDto.Document != userToUpdate.Document ? userInDto.Document : userToUpdate.Document;
                userToUpdate.Phone = !string.IsNullOrEmpty(userInDto.Phone) ? userInDto.Phone : userToUpdate.Phone;
                userToUpdate.PaymentType = !string.IsNullOrEmpty(userInDto.PaymentType) ? userInDto.PaymentType : userToUpdate.PaymentType;
                userToUpdate.State = !string.IsNullOrEmpty(userInDto.State) ? userInDto.State : userToUpdate.State;
                userToUpdate.AmountApproved = userInDto.AmountApproved != userToUpdate.AmountApproved  ? userInDto.AmountApproved : userToUpdate.AmountApproved;
                userToUpdate.Type = !string.IsNullOrEmpty(userInDto.Type) ? userInDto.Type : userToUpdate.Type;

                userRepository.Update(userToUpdate);
                userRepository.SaveChanges();
            }
            else
            {
                throw new NotFoundClientException();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task Dalete(int idUser)
        {
            User? userToDelete = await userRepository.GetByIdAsync(idUser);
            if (userToDelete != null)
            {
                userRepository.Delete(userToDelete);
                userRepository.SaveChangesAsync().GetAwaiter();
            }
        }

        public List<User?> SearchByParams(UserFindDto userFindDto)
        {
            List<User?> listFiltered = [];
            var predicateFilter = BuildPredicateSearchUser(userFindDto);


            listFiltered = (List<User?>)[.. userRepository.GetQueryable().AsNoTracking()
                                                          .Where(predicateFilter)
                            ];

            return listFiltered;
        }


        private static ExpressionStarter<User> BuildPredicateSearchUser(UserFindDto userFindDto)
        {
            ExpressionStarter<User> predicateFilter = PredicateBuilder.New<User>(true);


            if (userFindDto.Document > 0)
                predicateFilter.Or(e => e.Document == userFindDto.Document);

            if (!string.IsNullOrEmpty(userFindDto.DocumentType))
                predicateFilter.Or(e => e.DocumentType.ToLower().Equals(userFindDto.DocumentType));

            if (!string.IsNullOrEmpty(userFindDto.PaymentType))
                predicateFilter.Or(e => e.PaymentType.Trim().ToLower().Equals(userFindDto.PaymentType));

            if (!string.IsNullOrEmpty(userFindDto.Phone))
                predicateFilter.Or(e => e.Phone.Trim().ToLower().Equals(userFindDto.Phone));

            if (!string.IsNullOrEmpty(userFindDto.State))
                predicateFilter.Or(e => e.State.Trim().ToLower().Equals(userFindDto.State));

            return predicateFilter;

        }


    }
}
