using HotelBookingApp.DTOs;
using HotelBookingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;
        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelDto>> SearchHotelsByLocationAsync(string name, string location)
        {
            return await _context.Hotels
                .Include(h => h.Rooms)
                .Where(h => h.Location.ToLower().Contains(location.ToLower()) || h.Name.ToLower().Contains(name.ToLower()))
                .Select(h => new HotelDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    Rooms = h.Rooms.Select(r => new RoomDto
                    {
                        Id = r.Id,
                        RoomType = r.RoomType,
                        Price = r.PricePerNight,
                        IsAvailable = r.IsAvailable
                    }).ToList()
                })
                .ToListAsync();
        }

    }
}
