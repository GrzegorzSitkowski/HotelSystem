using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IHotelDbContext _context;

        public DeleteUserCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
