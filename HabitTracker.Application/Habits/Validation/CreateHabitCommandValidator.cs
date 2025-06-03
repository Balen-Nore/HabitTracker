using FluentValidation;
using HabitTracker.Application.Habits.Commands;

namespace HabitTracker.Application.Validation;

public class CreateHabitCommandValidator : AbstractValidator<CreateHabitCommand>
{
    public CreateHabitCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.TargetPerWeek).GreaterThan(0).LessThanOrEqualTo(7);
        RuleFor(x => x.StartDate).NotEmpty();
    }
}
