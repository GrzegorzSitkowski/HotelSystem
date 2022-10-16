using AutoMapper;
using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Queries.GetReservationDetail
{
    public class GetReservationDetailQueryHandler : IRequestHandler<GetReservationDetailQuery, ReservationDetailVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationDetailQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReservationDetailVm> Handle(GetReservationDetailQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            var reservationVm = _mapper.Map<ReservationDetailVm>(reservation);
            return reservationVm;
        }
    }
}
