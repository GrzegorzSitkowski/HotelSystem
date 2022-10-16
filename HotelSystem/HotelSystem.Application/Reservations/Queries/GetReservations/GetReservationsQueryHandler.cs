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

namespace HotelSystem.Application.Reservations.Queries.GetReservations
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, ReservationsVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationsQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReservationsVm> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _context.Reservations.AsNoTracking().Where(p => p.StatusId == 1)
                .ProjectTo<ReservationsVm>(_mapper.ConfigurationProvider).ToListAsync();

            return new ReservationsVm();
        }
    }
}
