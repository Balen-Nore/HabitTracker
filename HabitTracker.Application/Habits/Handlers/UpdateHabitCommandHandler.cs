using MediatR;
using AutoMapper;
using HabitTracker.Application.Habits.Commands;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.Habits.Handlers;

public class UpdateHabitCommandHandler : IRequestHandler<UpdateHabitCommand, HabitDto>
{
    private static readonly List<Habit> _habits = CreateHabitCommandHandler._habits;
    private readonly IMapper _mapper;

    public UpdateHabitCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitDto> Handle(UpdateHabitCommand request, CancellationToken cancellationToken)
    {
        var habit = _habits.FirstOrDefault(h => h.Id == request.Id);
        if (habit == null)
        {
            return Task.FromResult<HabitDto>(null!);
        }

        habit.Name = request.Name;
        habit.TargetPerWeek = request.TargetPerWeek;
        habit.StartDate = request.StartDate;

        return Task.FromResult(_mapper.Map<HabitDto>(habit));
    }
}
