using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;

        private readonly AppDbContext appDbContext;

        public CarService(AppDbContext appDbContex,
                          IRepository<Car> carRepository)
        {
            this.appDbContext = appDbContex;
            this.carRepository = carRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carInDto"></param>
        /// <returns></returns>
        public async Task<int> Create(CarInDto carInDto)
        {
            Car car = new()
            {
                Capacity = carInDto.Capacity,
                Available = carInDto.Available,
                Mileage = carInDto.Mileage,
                Make = carInDto.Make,
                YearModel = carInDto.YearModel,
                Cost = carInDto.Cost,
                Type = carInDto.Type,
                Model = carInDto.Model
            };

            carRepository.Insert(car);
            await carRepository.SaveChangesAsync();
            return 1;
        }


        public async Task Update(CarInDto carInDto)
        {
            Car? carToUpdate = await carRepository.GetByIdAsync(carInDto.IdCar);

            if (carToUpdate != null)
            {
                carToUpdate.IdCar = carInDto.IdCar != 0 ? carInDto.IdCar : carToUpdate.IdCar;
                carToUpdate.Type = !string.IsNullOrEmpty(carInDto.Type) ? carInDto.Type : carToUpdate.Type;
                carToUpdate.Capacity = carInDto.Capacity != 0 ? carInDto.Capacity : carToUpdate.Capacity;
                carToUpdate.Available = carInDto.Available ;
                carToUpdate.Mileage = carInDto.Mileage != 0 ? carInDto.Mileage : carToUpdate.Mileage;
                carToUpdate.Make = !string.IsNullOrEmpty(carInDto.Make) ? carInDto.Make : carToUpdate.Make;
                carToUpdate.Cost = carInDto.Cost != 0 ? carInDto.Cost : carToUpdate.Cost;
                carToUpdate.Type = !string.IsNullOrEmpty(carInDto.Type) ? carInDto.Type : carToUpdate.Type;
                carToUpdate.Model = carInDto.Model != 0 ? carInDto.Model : carToUpdate.Model;
                carToUpdate.YearModel = carInDto.YearModel != 0 ? carInDto.YearModel : carToUpdate.YearModel;

                carRepository.Update(carToUpdate);
                carRepository.SaveChanges();
            }
            else
            {
                //throw new NotFoundCarException();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCar"></param>
        /// <returns></returns>
        public async Task Delete(int idCar)
        {
            Car? carToDelete = await carRepository.GetByIdAsync(idCar);
            if (carToDelete != null)
            {
                carRepository.Delete(carToDelete);
                carRepository.SaveChangesAsync().GetAwaiter();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carFindDto"></param>
        /// <returns></returns>
        public async Task<List<Car?>> SearchByParams(CarFindDto carFindDto)
        {
            List<Car?> ListFiltered = [];

            ListFiltered = (List<Car?>)[.. carRepository.GetQueryable()
               .Where(x => x.Type == (!string.IsNullOrEmpty(carFindDto.Type) ? carFindDto.Type : x.Type) &&
                           x.Capacity == (carFindDto.Capacity > 0 ? carFindDto.Capacity : x.Capacity) &&
                           x.Available == carFindDto.Available &&
                           x.Mileage == (carFindDto.Mileage > 0  ? carFindDto.Mileage : x.Mileage) &&
                           x.Make == (!string.IsNullOrEmpty(carFindDto.Make) ? carFindDto.Make : x.Make) &&
                           x.Cost == (carFindDto.Cost > 0 ? carFindDto.Cost : x.Cost) &&
                           x.Model == (carFindDto.Model != 0 ? carFindDto.Model : x.Model) &&
                           x.SubModel == (carFindDto.SubModel != 0 ? carFindDto.SubModel : x.SubModel) &&
                           x.YearModel == (carFindDto.YearModel > 0 ? carFindDto.YearModel : x.YearModel)
                           )
                            ];



            return ListFiltered;
        }


    }
}
