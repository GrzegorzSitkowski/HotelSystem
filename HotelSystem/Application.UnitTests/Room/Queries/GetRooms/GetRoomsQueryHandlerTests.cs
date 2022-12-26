using Application.UnitTests.Common;
using AutoMapper;
using HotelSystem.Application.Rooms.Queries.GetRooms;
using HotelSystem.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Room.Queries.GetRooms
{
    [Collection("QueryCollection")]
    public class GetRoomsQueryHandlerTests
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetRooms()
        {
            var handler = new GetRoomsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetRoomsQuery(), CancellationToken.None);

            result.ShouldBeOfType<RoomsVm>();
        }
    }
}
