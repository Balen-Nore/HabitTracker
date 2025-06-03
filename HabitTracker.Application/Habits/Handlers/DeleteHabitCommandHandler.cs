using MediatR;
using HabitTracker.Application.Habits.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.Habits.Handlers;

public class DeleteHabitCommandHandler : IRequestHandler<DeleteHabitCommand, bool>
{
    private static readonly List<HabitTracker.Domain.Entities.Habit> _habits = CreateHabitCommandHandler._habits;

    public Task<bool> Handle(DeleteHabitCommand request, CancellationToken cancellationToken)
    {
        var habit = _habits.FirstOrDefault(h => h.Id == request.Id);
        if (habit == null)
            return Task.FromResult(false);

        _habits.Remove(habit);
        return Task.FromResult(true);
    }
}
