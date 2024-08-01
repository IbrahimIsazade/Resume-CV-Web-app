using FluentValidation;

namespace Services.Categories
{
    public class AddCategoryRequestDtoValidator : AbstractValidator<AddCategoryRequestDto>
    {
        public AddCategoryRequestDtoValidator() 
        {
            RuleFor(m => m.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Name must contain at least 2 letters");
        }
    }
}
