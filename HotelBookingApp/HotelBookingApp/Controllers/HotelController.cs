using HotelBookingApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchHotels([FromQuery] string location, [FromQuery] string? name = "")
        {
            var results = await _hotelRepository.SearchHotelsByLocationAsync(name, location);
            return Ok(results);
        }
    }
}
