using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            return _context.Cities.Select(c => new CityDto
            {
                cityId = c.CityId,
                name = c.Name
            }).ToList();
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            throw new NotImplementedException();
        }

    }
}