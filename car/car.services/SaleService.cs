using LinqKit;
using System.Linq.Dynamic.Core;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.model.Model;
using w.sale.car.model.statics;

namespace w.sale.car.services
{
    public class SaleService : ISaleService
    {
        private readonly IRepository<Sale> saleRepository;
        private readonly IRepository<Reserve> reserveRepository;

        private readonly AppDbContext appDbContext;

        public SaleService(AppDbContext appDbContex,
                               IRepository<Sale> saleRepository,
                               IRepository<Reserve> reserveRepository
                               )
        {
            this.appDbContext = appDbContex;
            this.saleRepository = saleRepository;
            this.reserveRepository = reserveRepository; 

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInDto"></param>
        /// <returns></returns>
        public async Task<int> Create(SaleInDto saleInDto)
        {
            Sale sale = new()
            {
               IdCar = saleInDto.IdCar,
               SnReserve = saleInDto.SnReserve,
               IdUser = saleInDto.IdUser,
               IdVendor = saleInDto.IdVendor,
               SaleDate = new DateTime(),
               Status = (w.sale.car.model.statics.StatusSale)StatusSale.Picked_Up,
               TotalSale = saleInDto.TotalSale,
               IdDeliveryLocation = saleInDto.IdDeliveryLocation
            };

            using (var transaction = appDbContext.Database.BeginTransaction())
            {
                saleRepository.Insert(sale);

                Reserve? reserve = reserveRepository.GetQueryable().FirstOrDefault(x => x.SN == saleInDto.SnReserve);

                if (reserve != null)
                {
                    reserve.DeliveryDate = new DateTime();
                    reserve.DoSale = true;
                    reserve.IdDeliveryLocation = sale.IdDeliveryLocation;

                    reserveRepository.Update(reserve);


                    try
                    {
                        await saleRepository.SaveChangesAsync();
                        await reserveRepository.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());

                        if (transaction != null)
                            await transaction.RollbackAsync();

                        return 0;
                    }

                }
            }


            return 1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSale"></param>
        /// <returns></returns>
        public async Task Dalete(int idSale)
        {
            Sale? saleToDelete = await saleRepository.GetByIdAsync(idSale);
            if (saleToDelete != null)
            {
                saleRepository.Delete(saleToDelete);
                saleRepository.SaveChangesAsync().GetAwaiter();
            }
        }

        public async Task<List<ReportFindDto?>> SearchByParams(SaleFindDto saleFindDto)
        {
            var predicateFilter = BuildPredicateSearch(saleFindDto);

            IQueryable<ReportFindDto> query = from sales in appDbContext.sale
                                    join res in appDbContext.reserve on sales.SnReserve equals res.SN
                                    select new ReportFindDto
                                    {
                                        IdSale = sales.IdSale,
                                        IdCar = sales.IdCar,
                                        Status = (int)sales.Status,
                                        SaleDate = sales.SaleDate,
                                        IdDeliveryLocation = sales.IdDeliveryLocation ,
                                        IdVendor = sales.IdVendor,
                                        IdUser = sales.IdUser,
                                        TotalSale = sales.TotalSale,
                                        SnReserve = sales.SnReserve,
                                        IdReserve = res.IdReserve,
                                        ReserveDate = res.ReserveDate,
                                        BaseCost = res.BaseCost,
                                        OthersCosts = res.OthersCosts
                                        };
 
            List<ReportFindDto?> listFiltered = [];
        
            listFiltered = query.Where(predicateFilter).ToList();


            return listFiltered;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveFindDto"></param>
        /// <returns></returns>
        private static ExpressionStarter<ReportFindDto> BuildPredicateSearch(SaleFindDto reserveFindDto)
        {
            int minYear = 2000;
            ExpressionStarter<ReportFindDto> predicateFilter = PredicateBuilder.New<ReportFindDto>(true);


            if (reserveFindDto.IdCar > 0)
                predicateFilter.Or(e => e.IdCar == reserveFindDto.IdCar);

            if (!String.IsNullOrEmpty(reserveFindDto.Status))
                predicateFilter.Or(e => e.Status.ToString() == reserveFindDto.Status.ToString());


            if (reserveFindDto.SaleDate != null && reserveFindDto.SaleDate.Value.Year > minYear)
                predicateFilter.Or(e => e.SaleDate <= reserveFindDto.SaleDate);

            if (reserveFindDto.IdDeliveryLocation > 0)
                predicateFilter.Or(e => e.IdDeliveryLocation == reserveFindDto.IdDeliveryLocation);

            if (reserveFindDto.IdVendor != null)
                predicateFilter.Or(e => e.IdVendor == reserveFindDto.IdVendor);

            if (reserveFindDto.IdUser != null)
                predicateFilter.Or(e => e.IdUser == reserveFindDto.IdUser);

            if (reserveFindDto.TotalSale != null)
                predicateFilter.Or(e => e.TotalSale == reserveFindDto.TotalSale);

            if (reserveFindDto.SnReserve != null)
                predicateFilter.Or(e => e.SnReserve == reserveFindDto.SnReserve);

            if (reserveFindDto.IdReserve != null)
                predicateFilter.Or(e => e.IdReserve == reserveFindDto.IdReserve);

            if (reserveFindDto.ReserveDate != null)
                predicateFilter.Or(e => e.ReserveDate == reserveFindDto.ReserveDate);

            if (reserveFindDto.BaseCost != null)
                predicateFilter.Or(e => e.BaseCost == reserveFindDto.BaseCost);

            if (reserveFindDto.OthersCosts != null)
                predicateFilter.Or(e => e.OthersCosts == reserveFindDto.OthersCosts);

            return predicateFilter;

        }


    }
}
