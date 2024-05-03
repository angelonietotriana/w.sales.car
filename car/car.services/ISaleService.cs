using w.sale.car.db.Dtos;

namespace w.sale.car.services
{
    public interface ISaleService
    {
        Task<int> Create(SaleInDto saleInDto);
        Task Dalete(int idSale);
        Task<List<ReportFindDto?>> SearchByParams(SaleFindDto saleFindDto);
    }
}
