using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.exceptions;
using w.sale.car.model.Model;

namespace w.sale.car.services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> locationRepository;

        private readonly AppDbContext appDbContext;

        public LocationService(AppDbContext appDbContex,
                               IRepository<Location> locationRepository)
        {
            this.appDbContext = appDbContex;
            this.locationRepository = locationRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationInDto"></param>
        /// <returns></returns>
        public async Task<int> Create(LocationInDto locationInDto)
        {
            Location location = new()
            {
                IdLocation = locationInDto.IdLocation,
                Available = locationInDto.Available,
                Locality = locationInDto.Locality,
                Zone = locationInDto.Zone,
                ZipCode = locationInDto.ZipCode
            };

            locationRepository.Insert(location);
            await locationRepository.SaveChangesAsync();
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationInDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Update(LocationInDto locationInDto)
        {
            Location? locationToUpdate = await locationRepository.GetByIdAsync(locationInDto.IdLocation);


            if (locationToUpdate != null)
            {
                locationToUpdate.IdLocation = locationInDto.IdLocation != 0 ? locationInDto.IdLocation : locationToUpdate.IdLocation;
                locationToUpdate.Available = locationInDto.Available;
                locationToUpdate.Locality = !string.IsNullOrEmpty(locationInDto.Locality) ? locationInDto.Locality : locationToUpdate.Locality;
                locationToUpdate.Zone = !string.IsNullOrEmpty(locationInDto.Zone) ? locationInDto.Zone : locationToUpdate.Zone;

                locationRepository.Update(locationToUpdate);
                locationRepository.SaveChanges();
            }
            else
            {
                throw new NotFoundLocationException();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idLocation"></param>
        /// <returns></returns>
        public async Task Delete(int idLocation)
        {
            Location? locationToDelete = await locationRepository.GetByIdAsync(idLocation);
            if (locationToDelete != null)
            {
                locationRepository.Delete(locationToDelete);
                locationRepository.SaveChangesAsync().GetAwaiter();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ubicacionInDto"></param>
        /// <returns></returns>
        public async Task<List<Location?>> SearchByParams(LocationFindDto ubicacionInDto)
        {
            List<Location?> listFiltered = [];

            listFiltered = (List<Location?>)[.. locationRepository.GetQueryable()
               .Where(x => x.ZipCode == (ubicacionInDto.ZipCode > 0 ? ubicacionInDto.ZipCode : x.ZipCode) &&
                           x.Available == ubicacionInDto.Available &&
                           x.Locality == (!string.IsNullOrEmpty(ubicacionInDto.Locality) ? ubicacionInDto.Locality : x.Locality) &&
                           x.Zone == (!string.IsNullOrEmpty(ubicacionInDto.Zone) ? ubicacionInDto.Zone : x.Zone) )
                            ];

            return listFiltered;
        }

    }
}
