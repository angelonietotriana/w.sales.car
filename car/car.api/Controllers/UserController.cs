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
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> userRepository;
        private readonly AppDbContext appDbContext;
        private IValidator<UserInDto> creaclienteValidator;

        public UserController(ILogger<UserController> logger,
                                AppDbContext appDbContext,
                                IRepository<User> userRepository,
                                IValidator<UserInDto> creaValidator)
        {
            _logger = logger;
            this.appDbContext = appDbContext;
            this.userRepository = userRepository;
            creaclienteValidator = creaValidator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UserInDto userInDto)
        {
            creaclienteValidator.ValidateAndThrow(userInDto);
            UserService service = new(appDbContext, userRepository);

            int id = await service.Create(userInDto);

            return Ok(id == 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete(), ActionName("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int idUser)
        {
            if (idUser == null)
            {
                throw new BadHttpRequestException("Id user is mandatory");
            }

            await new UserService(appDbContext, userRepository).Dalete(idUser);
            return Ok();
        }


        /// <summary>
        /// Se actualiza un registro con la información ingresada.
        /// Los campos que no se llenen quedarán con la información original.
        /// Campo Obligatario:
        /// Id del client.
        /// </summary>
        /// <param name="userInDto"></param>
        /// <returns></returns>
        [HttpPut, ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] UserInDto userInDto)
        {
            await new UserService(appDbContext, userRepository).Update(userInDto);

            return Ok();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFindDto"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Search")]
        [Route("Search")]
        public async Task<IActionResult> SearchBy([FromBody] UserFindDto userFindDto)
        {
            List<User?> filteredUsers = [];

            filteredUsers = new UserService(appDbContext, userRepository).SearchByParams(userFindDto);

            if (filteredUsers == null) { return NotFound(); }

            return Ok(filteredUsers);
        }


    }
}