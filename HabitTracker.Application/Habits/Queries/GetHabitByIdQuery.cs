using MediatR;
using HabitTracker.Application.Habits.Dtos;
using System;

namespace HabitTracker.Application.Habits.Queries;

public class GetHabitByIdQuery : IRequest<HabitDto>
{
    public Guid Id { get; set; }
    public GetHabitByIdQuery(Guid id)
    {
        Id = id;
    }
}
