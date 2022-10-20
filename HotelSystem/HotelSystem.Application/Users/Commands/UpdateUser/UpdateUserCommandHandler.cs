using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IHotelDbContext _context;
        public UpdateUserCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            user.Id = request.Id;
            user.Type = request.Type;
            user.Mail = request.Mail;
            user.Password = request.Password;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
