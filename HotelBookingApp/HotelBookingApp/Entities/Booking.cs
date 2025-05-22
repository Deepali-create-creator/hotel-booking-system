namespace HotelBookingApp.Entities
{
        public class Booking
        {
            public int Id { get; set; }
            public int HotelId { get; set; }
            public int RoomId { get; set; }
            public string GuestName { get; set; }
            public string GuestEmail { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }

            public Hotel Hotel { get; set; }
            public Room Room { get; set; }
        }
}
