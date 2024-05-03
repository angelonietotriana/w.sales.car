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
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly IRepository<Car> vehiculoRepository;
        private readonly AppDbContext appDbContext;
        private IValidator<CarInDto> creaVehiculoValidator;

        public CarController(ILogger<CarController> logger,
                                AppDbContext appDbContext,
                                IRepository<Car> vehiculoRepository,
                                IValidator<CarInDto> creaValidator)
        {
            _logger = logger;
            this.appDbContext = appDbContext;
            this.vehiculoRepository = vehiculoRepository;
            creaVehiculoValidator = creaValidator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carInDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("create")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CarInDto carInDto)
        {
            creaVehiculoValidator.ValidateAndThrow(carInDto);
            CarService service = new(appDbContext, vehiculoRepository);
            int id = await service.Create(carInDto);

            return Ok(id == 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCar"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete(), ActionName("delete")]
        public async Task<IActionResult> Delete([FromQuery] int IdCar)
        {
            if (IdCar == null)
            {
                throw new BadHttpRequestException("Id Vechículo obligatorio");
            }

            await new CarService(appDbContext, vehiculoRepository).Delete(IdCar);
            return Ok();
        }


        /// <summary>
        /// Se actualiza un registro con la información ingresada.
        /// Los campos que no se llenen quedarán con la información original.
        /// Campo Obligatario:
        /// Id de la car.
        /// </summary>
        /// <param name="carInDto"></param>
        /// <returns></returns>
        [HttpPut, ActionName("update")]
        public async Task<IActionResult> Update([FromBody] CarInDto carInDto)
        {
            await new CarService(appDbContext, vehiculoRepository).Update(carInDto);

            return Ok();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="carFindDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("search")]
        [Route("search")]
        public async Task<IActionResult> SearchBy([FromBody] CarFindDto carFindDto)
        {
            List<Car?> vehiculosFiltrados = [];

            vehiculosFiltrados = new CarService(appDbContext, vehiculoRepository).SearchByParams(carFindDto).GetAwaiter().GetResult();

            if (vehiculosFiltrados == null) { return NotFound(); }

            return Ok(vehiculosFiltrados);
        }


    }
}