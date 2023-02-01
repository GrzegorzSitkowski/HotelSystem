using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(20).MinimumLength(5);
            RuleFor(x => x.PhoneNumner).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PostCode).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
        }
    }
}
