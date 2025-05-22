namespace HotelBookingApp.DTOs
{
    public class CreateBookingDto
    {
            public int HotelId { get; set; }
            public int RoomId { get; set; }
            public string GuestName { get; set; }
            public string GuestEmail { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }

    }
}
