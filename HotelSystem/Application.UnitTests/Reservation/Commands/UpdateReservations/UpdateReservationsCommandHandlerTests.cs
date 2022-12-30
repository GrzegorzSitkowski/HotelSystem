using Application.UnitTests.Common;
using HotelSystem.Application.Reservations.Commands.UpdateReservation;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Reservation.Commands.UpdateReservations
{
    public class UpdateReservationsCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateReservationCommandHandler _handler;

        public UpdateReservationsCommandHandlerTests():
            base()
        {
            _handler = new UpdateReservationCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldEditReservation()
        {
            var command = new UpdateReservationCommand()
            {
                Id = 2,
                Price = 50,
                Mail = "test@test.net",
                Payment = false,
                CheckIn = new DateTime(2023, 01, 01),
                CheckOut = new DateTime(2023, 01, 07)
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var reservation = await _context.Reservations.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            reservation.Price.ShouldBe(50);
            reservation.Mail.ShouldBe("test@test.net");
            reservation.Payment.ShouldBe(false);
            reservation.UserId.ShouldBe(1);
            reservation.RoomId.ShouldBe(15);
            reservation.StatusId.ShouldBe(1);
        }
    }
}
