using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Sunrise Hotel",
                Location = "Mumbai",
                Description = "Luxury stay in the heart of Mumbai",
                ImageUrl = "https://images.pexels.com/photos/271624/pexels-photo-271624.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300"
            },
            new Hotel
            {
                Id = 2,
                Name = "Taj Palace",
                Location = "Delhi",
                Description = "A royal experience in the capital city",
                ImageUrl = "https://images.pexels.com/photos/259588/pexels-photo-259588.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300"
            },
            new Hotel
            {
                Id = 3,
                Name = "The Beach House",
                Location = "Goa",
                Description = "Beachside relaxation and luxury",
                ImageUrl = "https://images.pexels.com/photos/276724/pexels-photo-276724.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300"
            },
            new Hotel
            {
                Id = 4,
                Name = "Garden View Inn",
                Location = "Bangalore",
                Description = "Tranquil garden setting with modern comforts",
                ImageUrl = "https://images.pexels.com/photos/186077/pexels-photo-186077.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300"
            },
            new Hotel
            {
                Id = 5,
                Name = "Pink City Retreat",
                Location = "Jaipur",
                Description = "Stay in style amidst royal heritage",
                ImageUrl = "https://images.pexels.com/photos/271667/pexels-photo-271667.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300"
            }
        );



            modelBuilder.Entity<Room>().HasData(
        // Mumbai - Sunrise Hotel
        new Room { Id = 1, HotelId = 1, RoomType = "Single", PricePerNight = 3000, IsAvailable = true },
        new Room { Id = 2, HotelId = 1, RoomType = "Double", PricePerNight = 4500, IsAvailable = true },

        // Delhi - Taj Palace
        new Room { Id = 3, HotelId = 2, RoomType = "Deluxe", PricePerNight = 8000, IsAvailable = true },
        new Room { Id = 4, HotelId = 2, RoomType = "Suite", PricePerNight = 12000, IsAvailable = false },

        // Goa - The Beach House
        new Room { Id = 5, HotelId = 3, RoomType = "Cottage", PricePerNight = 6000, IsAvailable = true },
        new Room { Id = 6, HotelId = 3, RoomType = "Sea View", PricePerNight = 7000, IsAvailable = true },

        // Bangalore - Garden View Inn
        new Room { Id = 7, HotelId = 4, RoomType = "Single", PricePerNight = 2500, IsAvailable = true },
        new Room { Id = 8, HotelId = 4, RoomType = "Double", PricePerNight = 4000, IsAvailable = false },

        // Jaipur - Pink City Retreat
        new Room { Id = 9, HotelId = 5, RoomType = "Deluxe", PricePerNight = 5000, IsAvailable = true },
        new Room { Id = 10, HotelId = 5, RoomType = "Heritage Suite", PricePerNight = 9500, IsAvailable = true }
        );

            modelBuilder.Entity<Booking>()
               .HasOne(b => b.Hotel)
               .WithMany()
               .HasForeignKey(b => b.HotelId)
               .OnDelete(DeleteBehavior.NoAction); // prevent cascade from Hotel to Booking

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
