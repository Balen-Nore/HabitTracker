using MediatR;
using HabitTracker.Application.HabitLogs.Dtos;
using System;

namespace HabitTracker.Application.HabitLogs.Commands;

public class CreateHabitLogCommand : IRequest<HabitLogDto>
{
    public Guid HabitId { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }
}
