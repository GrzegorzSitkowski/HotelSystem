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

namespace HotelSystem.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IHotelDbContext _context;
        public CreateRoomCommandHandler(IHotelDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            Room room = new()
            {   
                Name = request.Name,
                Capacity = request.Capacity,
                Price = request.Price,
                Avability = request.Avability,
                Description = request.Description
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync(cancellationToken);

            return room.Id;
        }
    }
}
