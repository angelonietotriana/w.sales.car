using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.model.Model;
using w.sale.car.services;


namespace w.sale.car.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IRepository<Sale> saleRepository;
        private readonly IRepository<Reserve> reserveRepository;
        private readonly AppDbContext appDbContext;
        private IValidator<SaleInDto> createSaleValidator;

        public SaleController(ILogger<UserController> logger,
                                AppDbContext appDbContext,
                                IRepository<Sale> saleRepository,
                                IRepository<Reserve> reserveRepository,
                                IValidator<SaleInDto> saleValidator)
        {
            _logger = logger;
            this.appDbContext = appDbContext;
            this.saleRepository = saleRepository;
            this.reserveRepository = reserveRepository;
            createSaleValidator = saleValidator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] SaleInDto saleInDto)
        {
            createSaleValidator.ValidateAndThrow(saleInDto);
            SaleService service = new(appDbContext, saleRepository, reserveRepository);

            int id = await service.Create(saleInDto);

            return Ok(id == 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSale"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete(), ActionName("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int idSale)
        {
            if (idSale == null)
            {
                throw new BadHttpRequestException("Id user is mandatory");
            }

            await new SaleService(appDbContext, saleRepository, reserveRepository).Dalete(idSale);
            return Ok();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFindDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Search")]
        [Route("Search")]
        public async Task<IActionResult> SearchBy([FromBody] SaleFindDto saleFindDto)
        {
            List<ReportFindDto?> filteredUsers = [];

            filteredUsers = await new SaleService(appDbContext, saleRepository, reserveRepository).SearchByParams(saleFindDto);

            if (filteredUsers == null) { return NotFound(); }

            return Ok(filteredUsers);
        }


    }
}