using MediatR;
using AutoMapper;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Application.Habits.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.Habits.Handlers;

public class GetAllHabitsQueryHandler : IRequestHandler<GetAllHabitsQuery, List<HabitDto>>
{
    private static readonly List<HabitTracker.Domain.Entities.Habit> _habits = CreateHabitCommandHandler._habits;
    private readonly IMapper _mapper;

    public GetAllHabitsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<List<HabitDto>> Handle(GetAllHabitsQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<HabitDto>>(_habits);
        return Task.FromResult(result);
    }
}
