using LinqKit;
using Microsoft.EntityFrameworkCore;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;
using w.sale.car.services.Strategy;

namespace w.sale.car.services
{
    public class ReserveService : IReserveService
    {
        private readonly IRepository<Reserve> reserveRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Car> carRepository;
        private readonly IRepository<Location> locationRepository;

        private readonly AppDbContext appDbContext;

        public ReserveService(AppDbContext appDbContex,
                               IRepository<Reserve> reserveRepository,
                               IRepository<User> userRepository,
                               IRepository<Car> carRepository,
                               IRepository<Location> locationRepository)
        {
            this.appDbContext = appDbContex;
            this.reserveRepository = reserveRepository;
            this.userRepository = userRepository;
            this.carRepository = carRepository;
            this.locationRepository = locationRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveInDto"></param>
        /// <returns></returns>
        public async Task<int> Create(ReserveInDto reserveInDto)
        {
            await InValidations(reserveInDto);

        
            Reserve reserve = new()
            {
                SN = Guid.NewGuid().ToString(),
                IdClient = reserveInDto.IdClient,
                IdCar = reserveInDto.IdCar,
                IdCollectLocation = reserveInDto.IdCollectLocation,
                IdDeliveryLocation = reserveInDto.IdDeliveryLocation,
                CollectDate = reserveInDto.CollectDate,
                DeliveryDate = reserveInDto.DeliveryDate,
                ReserveDate = reserveInDto.CollectDate,
                BaseCost = reserveInDto.BaseCost,
                OthersCosts = reserveInDto.OthersCosts,
                DoSale = reserveInDto.DoSale
            };

            reserveRepository.Insert(reserve);
            await reserveRepository.SaveChangesAsync();
            return 1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idReserve"></param>
        /// <returns></returns>
        public async Task Delete(int idReserve)
        {
            Reserve? reserveToDelete = await reserveRepository.GetByIdAsync(idReserve);
            if (reserveToDelete != null)
            {
                reserveRepository.Delete(reserveToDelete);
                reserveRepository.SaveChangesAsync().GetAwaiter();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveInDto"></param>
        /// <returns></returns>
        public async Task Update(ReserveInDto reserveInDto)
        {
            InValidations(reserveInDto);

            Reserve? reserveToUpdate = await reserveRepository.GetByIdAsync(reserveInDto.IdReserve);

            if (reserveToUpdate != null)
            {
                bool dateReserveValid = reserveInDto.ReserveDate.Day >= DateTime.Now.Day && reserveInDto.ReserveDate.Year >= DateTime.Now.Year;
                bool dateCollectValid = reserveInDto.CollectDate.Day >= DateTime.Now.Day && reserveInDto.CollectDate.Year >= DateTime.Now.Year;
                bool dateValidDelivery = reserveInDto.DeliveryDate != null && 
                    reserveInDto.DeliveryDate.Value.Day >= DateTime.Now.Day && reserveInDto.DeliveryDate.Value.Year >= DateTime.Now.Year;
       
                reserveToUpdate.IdClient = reserveInDto.IdClient != 0 ? reserveInDto.IdClient : reserveToUpdate.IdClient;
                reserveToUpdate.IdCar = reserveInDto.IdCar != 0 ? reserveInDto.IdCar : reserveToUpdate.IdCar;
                reserveToUpdate.IdCollectLocation = reserveInDto.IdCollectLocation != 0 ? reserveInDto.IdCollectLocation : reserveToUpdate.IdCollectLocation;
                reserveToUpdate.IdDeliveryLocation = reserveInDto.IdDeliveryLocation != 0 ? reserveInDto.IdDeliveryLocation : reserveToUpdate.IdDeliveryLocation;
                reserveToUpdate.CollectDate = dateCollectValid ? reserveInDto.CollectDate : reserveToUpdate.CollectDate;
                reserveToUpdate.DeliveryDate = dateValidDelivery ? reserveInDto.DeliveryDate : reserveToUpdate.DeliveryDate;
                reserveToUpdate.BaseCost = reserveInDto.BaseCost > 0 ? reserveInDto.BaseCost : reserveToUpdate.BaseCost;
                reserveToUpdate.OthersCosts = reserveInDto.OthersCosts > 0 ? reserveInDto.OthersCosts : reserveToUpdate.OthersCosts;
                reserveToUpdate.DoSale = reserveInDto.DoSale;

                reserveRepository.Update(reserveToUpdate);
                reserveRepository.SaveChanges();
            }
            else
            {
                throw new NotFoundReserveException(NotFoundReserveException.Message);
            }



        }

        /// <summary>
        /// Encuetra el historial de reservas
        /// </summary>
        /// <param name="reserveFindDto"></param>
        /// <returns></returns>
        public async Task<List<Reserve?>> SearchByParams(ReserveFindDto reserveFindDto)
        {
            List<Reserve?> listFiltered = [];

            var predicateFilter = BuildPredicateSearch(reserveFindDto);

            listFiltered = (List<Reserve?>)[.. reserveRepository
                                                .GetQueryable()
                                                .AsNoTracking()
                                                .Where(predicateFilter)];

            return listFiltered;

        }

        /// <summary>
        /// Ejecuta las estrategias definidas para la creación de la reserve
        /// </summary>
        /// <param name="reservaInDto"></param>
        private async Task InValidations(ReserveInDto reservaInDto)
        {
            #region Validaciones existencia cliente con el id que llega
            ContextStrategy _validateReserveContext = new(new IsValidUser(this.userRepository,
                                                                           reservaInDto.IdClient));
            await _validateReserveContext.ExecuteStrategy();
            #endregion

            #region validacion exitencia de los id de las localidades existentes
            _validateReserveContext = new(new IsValidLocation(this.locationRepository,
                                                         reservaInDto.IdCollectLocation));
            await _validateReserveContext.ExecuteStrategy();

            if(reservaInDto.DoSale)
               _validateReserveContext = new(new IsValidLocation(this.locationRepository,
                                                              reservaInDto.IdDeliveryLocation??0));

            await _validateReserveContext.ExecuteStrategy();
            #endregion

            #region validacion existencia del id del vehículo enviado
            _validateReserveContext = new(new IsValidCar(this.carRepository,
                                                            reservaInDto.IdCar));
            await _validateReserveContext.ExecuteStrategy();
            #endregion
        }



        private static ExpressionStarter<Reserve> BuildPredicateSearch(ReserveFindDto reserveFindDto)
        {
            int minYear = 2000;
            ExpressionStarter<Reserve> predicateFilter = PredicateBuilder.New<Reserve>(true);


            if (reserveFindDto.IdCar > 0) 
                predicateFilter.Or(e => e.IdCar == reserveFindDto.IdCar);

            if (reserveFindDto.IdCollectLocation > 0)
                predicateFilter.Or(e => e.IdCollectLocation == reserveFindDto.IdCollectLocation);

            if (reserveFindDto.IdDeliveryLocation != null && reserveFindDto.IdDeliveryLocation > 0)
                predicateFilter.Or(e => e.IdDeliveryLocation == reserveFindDto.IdDeliveryLocation);

            if (reserveFindDto.DeliveryDate != null && reserveFindDto.DeliveryDate.Value.Year > minYear)
                predicateFilter.Or(e => e.DeliveryDate <= reserveFindDto.DeliveryDate);

            if (reserveFindDto.ReserveDate != null && reserveFindDto.ReserveDate.Value.Year > minYear)
                predicateFilter.Or(e => e.ReserveDate >= reserveFindDto.ReserveDate);

            if (reserveFindDto.CollectDate != null && reserveFindDto.CollectDate.Value.Year > minYear)
                predicateFilter.Or(e => e.CollectDate >= reserveFindDto.CollectDate);

            if (reserveFindDto.BaseCost > 0)
                predicateFilter.Or(e => e.BaseCost == reserveFindDto.BaseCost);

            if (reserveFindDto.OthersCosts > 0)
                predicateFilter.Or(e => e.OthersCosts == reserveFindDto.OthersCosts);

            if (reserveFindDto.OthersCosts != null)
                predicateFilter.Or(e => e.DoSale == reserveFindDto.DoSale);



            return predicateFilter;

        }
    }


}
