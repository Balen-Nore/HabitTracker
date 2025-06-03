using MediatR;
using AutoMapper;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Application.Habits.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.Habits.Handlers;

public class GetHabitByIdQueryHandler : IRequestHandler<GetHabitByIdQuery, HabitDto>
{
    private static readonly List<HabitTracker.Domain.Entities.Habit> _habits = CreateHabitCommandHandler._habits;
    private readonly IMapper _mapper;

    public GetHabitByIdQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitDto> Handle(GetHabitByIdQuery request, CancellationToken cancellationToken)
    {
        var habit = _habits.FirstOrDefault(h => h.Id == request.Id);
        return Task.FromResult(habit == null ? null! : _mapper.Map<HabitDto>(habit));
    }
}
