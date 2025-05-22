namespace HotelBookingApp.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
