using FluentValidation;
using Lunchroom.Domain.Interfaces;

namespace Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;

public class CreateLunchroomCommandValidator : AbstractValidator<CreateLunchroomCommand>
{
    public CreateLunchroomCommandValidator(ILunchroomRepository repository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(20);

        RuleFor(x => x.Description).NotEmpty().MinimumLength(10);
        RuleFor(x => x.Phone).MinimumLength(8).MaximumLength(12);

        RuleFor(x => x.Name).Custom((value, context) =>
        {
            var existingName = repository.GetMealByName(value).Result;
            if (existingName != null) context.AddFailure($"{value} is not unique Name");
        });
    }
}