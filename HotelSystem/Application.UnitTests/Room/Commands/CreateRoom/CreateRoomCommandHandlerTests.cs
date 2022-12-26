using Application.UnitTests.Common;
using HotelSystem.Application.Rooms.Commands.CreateRoom;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Room.Commands.CreateRoom
{
    public class CreateRoomCommandHandlerTests : CommandTestBase
    {
        private readonly CreateRoomCommandHandler _handler;

        public CreateRoomCommandHandlerTests():
            base()
        {
            _handler = new CreateRoomCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertRoom()
        {
            var command = new CreateRoomCommand
            {
                Name = "Test room",
                Capacity = 4,
                Price = 160,
                Avability = true,
                Description = "Room for tests."
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var room = await _context.Rooms.FirstAsync(x => x.Id == result, CancellationToken.None);

            room.ShouldNotBeNull();
            room.Name.ShouldBe("Test room");
            room.Price.ShouldBe(160);
            room.Avability.ShouldBe(true);
            room.Description.ShouldBe("Room for tests.");
        }
    }
}
