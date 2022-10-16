using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IHotelDbContext _context;
        public DeleteReservationCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
