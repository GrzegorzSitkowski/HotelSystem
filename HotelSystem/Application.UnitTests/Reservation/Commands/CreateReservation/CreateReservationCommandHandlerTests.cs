using Application.UnitTests.Common;
using HotelSystem.Application.Reservations.Commands.CreateReservation;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandlerTests : CommandTestBase
    {
        private readonly CreateReservationCommandHandler _handler;

        public CreateReservationCommandHandlerTests()
            : base()
        {
            _handler = new CreateReservationCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertReservation()
        {
            var command = new CreateReservationCommand()
            {
                Price = 65,
                Mail = "mail@example.pl",
                CheckIn = new DateTime(2022,12,19),
                CheckOut = new DateTime(2022,12,31),
                Payment = true,
                UserId = 10,
                RoomId = 7
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var res = await _context.Reservations.FirstAsync(x => x.Id == result, CancellationToken.None);

            res.ShouldNotBeNull();
        }
    }
}
