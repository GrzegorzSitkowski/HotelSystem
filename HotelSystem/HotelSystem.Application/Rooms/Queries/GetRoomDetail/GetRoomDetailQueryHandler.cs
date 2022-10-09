using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRoomDetail
{
    public class GetRoomDetailQueryHandler : IRequestHandler<GetRoomDetailQuery, RoomDetailVm>
    {
        private readonly IHotelDbContext _context;
        public GetRoomDetailQueryHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<RoomDetailVm> Handle(GetRoomDetailQuery request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            var roomVm = new RoomDetailVm()
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Price = room.Price,
                Avability = room.Avability,
                Description = room.Description
            };

            return roomVm;
        }
    }
}
