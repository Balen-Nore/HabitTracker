using MediatR;

namespace HabitTracker.Application.Habits.Commands;

public class DeleteHabitCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
