using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;
using w.sale.car.services;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace w.sale.car.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReserveController : ControllerBase
    {

        private readonly ILogger<ReserveController> _logger;
        private readonly IRepository<Reserve> reservaRepository;
        private readonly IRepository<Car> vehiculoRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Location> ubicacionRepository;

        private readonly AppDbContext appDbContext;
        private IValidator<ReserveInDto> reservaValidator;


        public ReserveController(ILogger<ReserveController> logger,
                                AppDbContext appDbContext,
                                IRepository<Reserve> reservaRepository,
                                IRepository<Car> vehiculoRepository,
                                IRepository<User> userRepository,
                                IRepository<Location> ubicacionRepository,
                                IValidator<ReserveInDto> reservaValidator
                                )
        {
            _logger = logger;
            this.appDbContext = appDbContext;
            this.reservaValidator = reservaValidator;
            this.reservaRepository = reservaRepository;
            this.vehiculoRepository = vehiculoRepository;
            this.userRepository = userRepository; 
            this.ubicacionRepository = ubicacionRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveInDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("create")]
        [Route("create")]
        public async Task<IActionResult> Crea([FromBody] ReserveInDto reserveInDto)
        {
            //var reservaJsonObject = JsonConvert.DeserializeObject<ReserveInDto>(reserveInDto);


            reservaValidator.ValidateAndThrow(reserveInDto);
            ReserveService service = new(appDbContext,
                                         reservaRepository,
                                         userRepository,
                                         vehiculoRepository,
                                         ubicacionRepository);
            int id = 0;
            try
            {
               id = await service.Create(reserveInDto);

            } catch (Exception ex) 
            {
                Dictionary<string, String> error = new Dictionary<string, string>();

                if (ex is NotFoundClientException || 
                    ex is NotFoundReserveException || 
                    ex is NotFoundCarException || 
                    ex is NotFoundLocationException)
                {
                    error.Add("Message:", ex.Message);
                    return NotFound(error);                }
                else
                {
                    throw ex;
                }
            }
             

            return Ok(id == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdReserve"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete, ActionName("delete")]
        public async Task<IActionResult> Delete([FromQuery] int IdReserve)
        {
            if (IdReserve == null)
            {
                throw new BadHttpRequestException("Required id reserve");
            }

            await new ReserveService(appDbContext,
                                      reservaRepository,
                                      userRepository,
                                      vehiculoRepository,
                                      ubicacionRepository).Delete(IdReserve);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveInDto"></param>
        /// <returns></returns>
        [HttpPut, ActionName("update")]
        public async Task<IActionResult> update([FromBody] ReserveInDto reserveInDto)
        {
            await new ReserveService(appDbContext,
                                     reservaRepository,
                                     userRepository,
                                     vehiculoRepository,
                                     ubicacionRepository).Update(reserveInDto);

            return Ok();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveFindDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("search")]
        [Route("search")]
        public async Task<IActionResult> SearchBy([FromBody] ReserveFindDto reserveFindDto)
        {
            List<Reserve?> reservasFiltradas = [];

            reservasFiltradas = new ReserveService(appDbContext, 
                                                    reservaRepository, 
                                                    userRepository,
                                                    vehiculoRepository,
                                                    ubicacionRepository)
                                    .SearchByParams(reserveFindDto).GetAwaiter().GetResult();

            if (reservasFiltradas == null) { return NotFound(); }

            return Ok(reservasFiltradas);
        }

    }
}