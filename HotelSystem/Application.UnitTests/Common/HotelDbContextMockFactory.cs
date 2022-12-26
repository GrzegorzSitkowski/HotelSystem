using HotelSystem.Application.Interfaces;
using HotelSystem.Domain.Entities;
using HotelSystem.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public static class HotelDbContextMockFactory
    {
        public static Mock<HotelDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<ICurrentUserService>();
            currentUserMock.Setup(m => m.userName).Returns("userTest");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<HotelDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<HotelDbContext>(options, dateTimeMock.Object, currentUserMock.Object) { CallBase = true };

            var context = mock.Object;

            context.Database.EnsureCreated();

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
            return mock;
        }

        public static void Destroy(HotelDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
