using FluentValidation;
using HabitTracker.Application.HabitLogs.Commands;

namespace HabitTracker.Application.Validation;

public class CreateHabitLogCommandValidator : AbstractValidator<CreateHabitLogCommand>
{
    public CreateHabitLogCommandValidator()
    {
        RuleFor(x => x.HabitId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
    }
}
