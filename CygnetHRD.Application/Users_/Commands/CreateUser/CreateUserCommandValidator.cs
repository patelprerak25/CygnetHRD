using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygnetHRD.Application.Users_.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Users.FirstName)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(v => v.Users.LastName)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(v => v.Users.DateOfBirth)
                .NotEmpty()
                .LessThan(v => DateTime.Now);
            RuleFor(v => v.Users.Email)
                .EmailAddress()
                .NotEmpty();
            RuleFor(v => v.Users.Password)
                .Length(8, 50)
                .NotEmpty();
        }
    }
}

