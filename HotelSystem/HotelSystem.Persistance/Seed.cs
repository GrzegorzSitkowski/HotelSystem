using HotelSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities()
                {
                    Id = 1,
                    EntireApartment = true,
                    PrivateBathroom = true,
                    PrivateKitchenette = true,
                    CityView = false,
                    AirConditioning = true,
                    Patio = false,
                    Dishwasher = false,
                    Tv = true,
                    CoffeeMachine = false,
                    WiFi = true
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation()
                {
                    Id = 1,
                    Mail = "example@mail.com",
                    Payment = true,
                    UserId = 1,
                    RoomId = 1
                });
        }
    }
}
