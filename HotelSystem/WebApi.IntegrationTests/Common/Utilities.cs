using HotelSystem.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static void InitializeDbForTests(HotelDbContext context)
        {
            var reservation = new HotelSystem.Domain.Entities.Reservation()
            {
                Id = 2,
                Price = 300,
                Mail = "mail@example.com",
                Payment = true,
                UserId = 1,
                RoomId = 15,
                StatusId = 1
            };
            context.Reservations.Add(reservation);

            var room = new HotelSystem.Domain.Entities.Room()
            {
                Id = 15,
                Name = "Double room",
                Capacity = 2,
                Price = 260,
                Avability = true,
                Description = "Room for two.",
                StatusId = 1
            };
            context.Rooms.Add(room);

            context.SaveChanges();
        }
    }
}
