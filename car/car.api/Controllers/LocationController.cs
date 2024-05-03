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
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;
        private readonly IRepository<Location> ubicacionRepository;
        private readonly AppDbContext appDbContext;
        private IValidator<LocationInDto> ubicacionValidator;

        public LocationController(ILogger<LocationController> logger,
                                AppDbContext appDbContext,
                                IRepository<Location> ubicacionRepository,
                                IValidator<LocationInDto> ubicacionValidator)
        {
            _logger = logger;
            this.appDbContext = appDbContext;
            this.ubicacionRepository = ubicacionRepository;
            this.ubicacionValidator = ubicacionValidator;
        }

        /// <summary>
        /// Permite crear una Location.
        /// los cambio obligatorios son:
        ///    - Available
        ///    - zona
        ///    - localidad
        /// </summary>
        /// <param name="locationInDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("create")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] LocationInDto locationInDto)
        {
            ubicacionValidator.ValidateAndThrow(locationInDto);
            LocationService service = new(appDbContext, ubicacionRepository);
            int id = await service.Create(locationInDto);

            return Ok(id == 1);
        }


        /// <summary>
        /// Se borra el registro de la Location con el identificador de la misma. 
        /// </summary>
        /// <param name="IdLocation"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete, ActionName("delete")]
        public async Task<IActionResult> Delete([FromQuery] int IdLocation)
        {
            if (IdLocation == null)
            {
                throw new BadHttpRequestException("Id location obligatorio");
            }

            await new LocationService(appDbContext, ubicacionRepository).Delete(IdLocation);

            return Ok();
        }


        /// <summary>
        /// Se actualiza un registro con la información ingresada.
        /// Los campos que no se llenen quedarán con la información original.
        /// Campo Obligatario:
        /// Objecto a consultar con el id como un dato obligatorio y acertado.
        /// </summary>
        /// <param name="locationInDto"></param>
        /// <returns></returns>
        [HttpPut, ActionName("update")]
        public async Task<IActionResult> Update([FromBody] LocationInDto locationInDto)
        {
            await new LocationService(appDbContext, ubicacionRepository).Update(locationInDto);

            return Ok();
        }

        /// <summary>
        /// Consulta el listado de las ubicaciones que existen en la base de datos.
        ///
        /// </summary>
        /// <param name="locationFindDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("search")]
        [Route("search")]
        public async Task<IActionResult> SearchBy([FromBody] LocationFindDto locationFindDto)
        {
            List<Location?> ubicacionesFiltradas = [];

            ubicacionesFiltradas = new LocationService(appDbContext, ubicacionRepository).SearchByParams(locationFindDto).GetAwaiter().GetResult();

            if (ubicacionesFiltradas == null) { return NotFound(); }

            return Ok(ubicacionesFiltradas);
        }



    }
}