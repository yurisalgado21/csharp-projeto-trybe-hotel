using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var hotel = _context.Hotels.First(h => h.HotelId == HotelId);

            hotel.City = _context.Cities.First(c => c.CityId == hotel.CityId);

            return _context.Rooms.Select(r => new RoomDto
            {
                roomId = r.RoomId,
                name = r.Name,
                capacity = r.Capacity,
                image = r.Image,
                hotel = new HotelDto {
                    hotelId = hotel.HotelId,
                    name = hotel.Name,
                    address = hotel.Address,
                    cityId = hotel.CityId,
                    cityName = hotel.City!.Name
                }
            }).ToList();
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            throw new NotImplementedException(); 
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId) {
            throw new NotImplementedException();
        }
    }
}