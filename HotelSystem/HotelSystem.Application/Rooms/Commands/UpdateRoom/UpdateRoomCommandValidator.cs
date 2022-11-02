using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Capacity).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(100);
        }
    }
}
