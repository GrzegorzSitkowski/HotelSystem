using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CheckIn).NotEmpty();
            RuleFor(x => x.CheckOut).NotEmpty();
        }
    }
}
