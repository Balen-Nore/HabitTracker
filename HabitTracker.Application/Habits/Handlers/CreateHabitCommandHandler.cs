using MediatR;
using AutoMapper;
using HabitTracker.Application.Habits.Commands;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.Habits.Handlers;

public class CreateHabitCommandHandler : IRequestHandler<CreateHabitCommand, HabitDto>
{
    public static readonly List<Habit> _habits = new List<Habit>();
    private readonly IMapper _mapper;

    public CreateHabitCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitDto> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
    {
        var habit = new Habit
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            TargetPerWeek = request.TargetPerWeek,
            StartDate = request.StartDate
        };

        _habits.Add(habit);

        return Task.FromResult(_mapper.Map<HabitDto>(habit));
    }
}
