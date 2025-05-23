﻿// <auto-generated />
using System;
using HotelBookingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBookingApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelBookingApp.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelBookingApp.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Luxury stay in the heart of Mumbai",
                            ImageUrl = "https://images.pexels.com/photos/271624/pexels-photo-271624.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300",
                            Location = "Mumbai",
                            Name = "Sunrise Hotel"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A royal experience in the capital city",
                            ImageUrl = "https://images.pexels.com/photos/259588/pexels-photo-259588.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300",
                            Location = "Delhi",
                            Name = "Taj Palace"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Beachside relaxation and luxury",
                            ImageUrl = "https://images.pexels.com/photos/276724/pexels-photo-276724.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300",
                            Location = "Goa",
                            Name = "The Beach House"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Tranquil garden setting with modern comforts",
                            ImageUrl = "https://images.pexels.com/photos/186077/pexels-photo-186077.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300",
                            Location = "Bangalore",
                            Name = "Garden View Inn"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Stay in style amidst royal heritage",
                            ImageUrl = "https://images.pexels.com/photos/271667/pexels-photo-271667.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=300",
                            Location = "Jaipur",
                            Name = "Pink City Retreat"
                        });
                });

            modelBuilder.Entity("HotelBookingApp.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 0,
                            HotelId = 1,
                            IsAvailable = true,
                            PricePerNight = 3000m,
                            RoomType = "Single"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 0,
                            HotelId = 1,
                            IsAvailable = true,
                            PricePerNight = 4500m,
                            RoomType = "Double"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 0,
                            HotelId = 2,
                            IsAvailable = true,
                            PricePerNight = 8000m,
                            RoomType = "Deluxe"
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 0,
                            HotelId = 2,
                            IsAvailable = false,
                            PricePerNight = 12000m,
                            RoomType = "Suite"
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 0,
                            HotelId = 3,
                            IsAvailable = true,
                            PricePerNight = 6000m,
                            RoomType = "Cottage"
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 0,
                            HotelId = 3,
                            IsAvailable = true,
                            PricePerNight = 7000m,
                            RoomType = "Sea View"
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 0,
                            HotelId = 4,
                            IsAvailable = true,
                            PricePerNight = 2500m,
                            RoomType = "Single"
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 0,
                            HotelId = 4,
                            IsAvailable = false,
                            PricePerNight = 4000m,
                            RoomType = "Double"
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 0,
                            HotelId = 5,
                            IsAvailable = true,
                            PricePerNight = 5000m,
                            RoomType = "Deluxe"
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 0,
                            HotelId = 5,
                            IsAvailable = true,
                            PricePerNight = 9500m,
                            RoomType = "Heritage Suite"
                        });
                });

            modelBuilder.Entity("HotelBookingApp.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelBookingApp.Entities.Booking", b =>
                {
                    b.HasOne("HotelBookingApp.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HotelBookingApp.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelBookingApp.Entities.Room", b =>
                {
                    b.HasOne("HotelBookingApp.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelBookingApp.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
