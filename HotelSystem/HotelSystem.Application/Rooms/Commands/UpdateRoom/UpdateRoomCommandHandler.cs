using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IHotelDbContext _context;
        public UpdateRoomCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            room.Id = request.Id;
            room.Name = request.Name;
            room.Capacity = request.Capacity;
            room.Price = request.Price;
            room.Avability = request.Avability;
            room.Amenities = request.Amenities;
            room.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
