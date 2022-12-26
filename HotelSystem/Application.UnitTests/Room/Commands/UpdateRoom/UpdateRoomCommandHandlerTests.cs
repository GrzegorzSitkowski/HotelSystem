using Application.UnitTests.Common;
using HotelSystem.Application.Rooms.Commands.UpdateRoom;
using HotelSystem.Persistance;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Room.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateRoomCommandHandler _handler;

        public UpdateRoomCommandHandlerTests()
            :base()
        {
            _handler = new UpdateRoomCommandHandler(_context);
        }

        [Fact]
        public async Task CanEditRoom()
        {
            var command = new UpdateRoomCommand
            {
                Id = 15,
                Name = "Edit room",
                Capacity = 1,
                Price = 55,
                Avability = false,
                Description = "Room has been edited."
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var room = await _context.Rooms.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            room.Name.ShouldBe("Edit room");
            room.Capacity.ShouldBe(1);
            room.Price.ShouldBe(55);
            room.Avability.ShouldBe(false);
            room.Description.ShouldBe("Room has been edited.");
        }
    }
}
