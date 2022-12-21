using Application.UnitTests.Common;
using AutoMapper;
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

namespace Application.UnitTests.Reservation.Queries.GetReservations
{
    [Collection("QueryCollection")]
    public class GetReservationsQueryHandlerTests
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetReservations()
        {
            var handler = new GetReservationsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetReservationsQuery(), CancellationToken.None);

            result.ShouldBeOfType<ReservationsVm>();
        }
    }
}
