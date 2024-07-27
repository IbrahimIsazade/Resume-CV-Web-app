using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ContactPost
{
    public class AddContactPostRequestDtoValidator : AbstractValidator<AddContactPostRequestDto>
    {
        public AddContactPostRequestDtoValidator()
        {

            RuleFor(m => m.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email cannot be empty");

            RuleFor(m => m.Subject)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Subject must be at least 2 symbols");

            RuleFor(m => m.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Subject must be at least 2 symbols");

            RuleFor(m => m.Content)
                .NotNull()
                .NotEmpty()
                .MinimumLength(20)
                .WithMessage("Content must be at least 20 symbols");
            }
    }
}
