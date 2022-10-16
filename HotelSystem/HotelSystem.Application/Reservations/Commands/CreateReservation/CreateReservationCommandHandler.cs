using HotelSystem.Application.Interfaces;
using HotelSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IHotelDbContext _context;

        public CreateReservationCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = new()
            {
                Price = request.Price,
                Mail = request.Mail,
                CheckIn = request.CheckIn,
                CheckOut = request.CheckOut,
                Payment = request.Payment,
                UserId = request.UserId,
                RoomId = request.RoomId
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return reservation.Id;
        }
    }
}
