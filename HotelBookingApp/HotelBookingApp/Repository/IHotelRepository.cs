using HotelBookingApp.DTOs;

namespace HotelBookingApp.Repository
{
    public interface IHotelRepository
    {
        Task<List<HotelDto>> SearchHotelsByLocationAsync(string name, string location);
    }
}
