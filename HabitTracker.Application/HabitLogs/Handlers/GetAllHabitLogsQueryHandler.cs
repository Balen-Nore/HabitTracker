using MediatR;
using AutoMapper;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Application.HabitLogs.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.HabitLogs.Handlers;

public class GetAllHabitLogsQueryHandler : IRequestHandler<GetAllHabitLogsQuery, List<HabitLogDto>>
{
    private static readonly List<HabitLog> _habitLogs = CreateHabitLogCommandHandler._habitLogs;
    private readonly IMapper _mapper;

    public GetAllHabitLogsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<List<HabitLogDto>> Handle(GetAllHabitLogsQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<HabitLogDto>>(_habitLogs);
        return Task.FromResult(result);
    }
}
