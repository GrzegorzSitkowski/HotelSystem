using AutoMapper;
using HotelSystem.Application.Interfaces;
using HotelSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IHotelDbContext _context;

        public CreateUserCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Type = request.Type,
                Mail = request.Mail,
                Password = request.Password,
                PhoneNumner = request.PhoneNumner,
                Address = request.Address,
                PostCode = request.PostCode,
                City = request.City
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
