using MediatR;
using System;

namespace HabitTracker.Application.HabitLogs.Commands;

public class DeleteHabitLogCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
