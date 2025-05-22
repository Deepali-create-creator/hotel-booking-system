using HotelBookingApp.DTOs;
using HotelBookingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom([FromBody] CreateBookingDto booking)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(b => b.HotelId == booking.HotelId && b.Id == booking.RoomId);
            if (room == null || !room.IsAvailable)
            {
                return BadRequest("Room is not available.");
            }

            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == booking.HotelId);
            var beingBookedRoom = await _context.Rooms.FirstOrDefaultAsync(h => h.Id == booking.RoomId);

            Booking newBooking = new Booking
            {
                HotelId = booking.HotelId,
                RoomId = booking.RoomId,
                GuestEmail = booking.GuestEmail,
                GuestName = booking.GuestName,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                Hotel = hotel,
                Room = beingBookedRoom
            };
            // Update availability
            room.IsAvailable = false;
            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Room booked successfully." });
        }
    }
}

