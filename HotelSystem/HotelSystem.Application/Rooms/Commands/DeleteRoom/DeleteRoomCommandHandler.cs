using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IHotelDbContext _context;
        public DeleteRoomCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
           var room = await _context.Rooms.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public object Handle(DeleteRoomCommand command, object none)
        {
            throw new NotImplementedException();
        }
    }
}
