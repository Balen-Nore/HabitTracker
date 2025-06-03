using MediatR;
using HabitTracker.Application.HabitLogs.Dtos;
using System;

namespace HabitTracker.Application.HabitLogs.Queries;

public class GetHabitLogByIdQuery : IRequest<HabitLogDto>
{
    public Guid Id { get; set; }
    public GetHabitLogByIdQuery(Guid id)
    {
        Id = id;
    }
}
