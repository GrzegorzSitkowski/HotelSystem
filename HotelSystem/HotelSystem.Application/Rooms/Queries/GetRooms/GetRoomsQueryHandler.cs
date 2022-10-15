using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, RoomsVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoomsVm> Handle(GetRoomsQuery request, CancellationToken none)
        {
            var rooms = await _context.Rooms.AsNoTracking().Where(p => p.StatusId == 1 && p.Avability == true).
                ProjectTo<RoomsVm>(_mapper.ConfigurationProvider).ToListAsync();

            return new RoomsVm();
        }
    }
}
