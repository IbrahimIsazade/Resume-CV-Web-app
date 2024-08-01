using FluentValidation;

namespace Services.Categories
{
    public class EditCategoryRequestDtoValidator : AbstractValidator<EditCategoryDto>
    {
        public EditCategoryRequestDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Name must contain at least 2 letters");
        }
    }
}
