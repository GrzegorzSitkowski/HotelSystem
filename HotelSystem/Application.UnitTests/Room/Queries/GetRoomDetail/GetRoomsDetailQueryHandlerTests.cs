using Application.UnitTests.Common;
using AutoMapper;
using HotelSystem.Application.Rooms.Queries.GetRoomDetail;
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

namespace Application.UnitTests.Room.Queries.GetRoomDetail
{
    [Collection("QueryCollection")]
    public class GetRoomsDetailQueryHandlerTests
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsDetailQueryHandlerTests(QueryTestFixtures fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task CanGetRoomDetailById()
        {
            var handler = new GetRoomDetailQueryHandler(_context, _mapper);
            var roomId = 15;

            var result = await handler.Handle(new GetRoomDetailQuery { Id = roomId }, CancellationToken.None);

            result.ShouldBeOfType<RoomDetailVm>();
            result.Name.ShouldBe("Double room");
            result.Capacity.ShouldBe(2);
            result.Price.ShouldBe(260);
            result.Description.ShouldBe("Room for two.");
        }
    }
}
