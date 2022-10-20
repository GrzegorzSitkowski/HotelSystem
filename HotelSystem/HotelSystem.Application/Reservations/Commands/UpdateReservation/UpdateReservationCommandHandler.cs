using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IHotelDbContext _context;

        public UpdateReservationCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            reservation.Id = request.Id;
            reservation.Price = request.Price;
            reservation.Mail = request.Mail;
            reservation.CheckIn = request.CheckOut;
            reservation.Payment = request.Payment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
