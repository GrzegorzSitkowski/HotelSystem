using Application.UnitTests.Common;
using HotelSystem.Application.Rooms.Commands.DeleteRoom;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Room.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteRoomCommandHandler _handler;

        public DeleteRoomCommandHandlerTests():
            base()
        {
            _handler = new DeleteRoomCommandHandler(_context);
        }

        [Fact]
        public async Task CanDeleteRoom()
        {
            var command = new DeleteRoomCommand
            {
                Id = 15
            };

            var result = _handler.Handle(command, CancellationToken.None);

            var room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == command.Id && p.StatusId == 1, CancellationToken.None);

            room.ShouldBeNull();
        }
    }
}
