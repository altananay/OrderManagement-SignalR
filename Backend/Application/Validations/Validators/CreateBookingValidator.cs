using Domain.Entities;
using FluentValidation;

namespace Application.Validations.Validators;

public class CreateBookingValidator : AbstractValidator<Booking>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name boş olamaz");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone boş olamaz");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olamaz");
        RuleFor(x => x.PersonCount).NotEmpty().WithMessage("PersonCount boş olamaz");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date boş olamaz");

        RuleFor(x => x.Name).MinimumLength(5).WithMessage("Min length 5").MaximumLength(50).WithMessage("Max length 5");
        RuleFor(x => x.Description).MaximumLength(50).WithMessage("Max length 5");
    }
}