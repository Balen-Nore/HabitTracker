using MediatR;
using HabitTracker.Application.HabitLogs.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.HabitLogs.Handlers;

public class DeleteHabitLogCommandHandler : IRequestHandler<DeleteHabitLogCommand, bool>
{
    private static readonly List<HabitLog> _habitLogs = CreateHabitLogCommandHandler._habitLogs;

    public Task<bool> Handle(DeleteHabitLogCommand request, CancellationToken cancellationToken)
    {
        var habitLog = _habitLogs.FirstOrDefault(h => h.Id == request.Id);
        if (habitLog == null)
            return Task.FromResult(false);

        _habitLogs.Remove(habitLog);
        return Task.FromResult(true);
    }
}
