using MediatR;
using AutoMapper;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Application.HabitLogs.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.HabitLogs.Handlers;

public class GetHabitLogByIdQueryHandler : IRequestHandler<GetHabitLogByIdQuery, HabitLogDto>
{
    private static readonly List<HabitLog> _habitLogs = CreateHabitLogCommandHandler._habitLogs;
    private readonly IMapper _mapper;

    public GetHabitLogByIdQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitLogDto> Handle(GetHabitLogByIdQuery request, CancellationToken cancellationToken)
    {
        var habitLog = _habitLogs.FirstOrDefault(h => h.Id == request.Id);
        return Task.FromResult(habitLog == null ? null! : _mapper.Map<HabitLogDto>(habitLog));
    }
}
