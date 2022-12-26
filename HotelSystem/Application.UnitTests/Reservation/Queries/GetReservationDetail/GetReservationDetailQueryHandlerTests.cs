using Application.UnitTests.Common;
using AutoMapper;
using HotelSystem.Application.Reservations.Queries.GetReservationDetail;
using HotelSystem.Application.Reservations.Queries.GetReservations;
using HotelSystem.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Reservation.Queries
{
    [Collection("QueryCollection")]
    public class GetReservationDetailQueryHandlerTests
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationDetailQueryHandlerTests(QueryTestFixtures fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task CanGetReservationDetalById()
        {
            var handler = new GetReservationDetailQueryHandler(_context, _mapper);
            var reservationId = 2;

            var result = await handler.Handle(new GetReservationDetailQuery { Id = reservationId }, CancellationToken.None);

            result.ShouldBeOfType<ReservationDetailVm>();
            result.Price.ShouldBe(300);
        }
    }
}
