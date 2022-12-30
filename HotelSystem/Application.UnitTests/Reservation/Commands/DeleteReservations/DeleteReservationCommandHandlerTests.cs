using Application.UnitTests.Common;
using HotelSystem.Application.Reservations.Commands.DeleteReservation;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Reservation.Commands.DeleteReservations
{
    public class DeleteReservationCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteReservationCommandHandler _handler;

        public DeleteReservationCommandHandlerTests()
            : base()
        {
            _handler = new DeleteReservationCommandHandler(_context);
        }

        [Fact]
        public async Task CanDeleteReservation()
        {
            var command = new DeleteReservationCommand()
            {
                Id = 2
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var reservation = await _context.Reservations.FirstOrDefaultAsync(p => p.Id == command.Id && p.StatusId == 1, CancellationToken.None);

            reservation.ShouldBeNull();
        }
    }
}
