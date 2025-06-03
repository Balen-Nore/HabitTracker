using MediatR;
using AutoMapper;
using HabitTracker.Application.HabitLogs.Commands;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.HabitLogs.Handlers;

public class UpdateHabitLogCommandHandler : IRequestHandler<UpdateHabitLogCommand, HabitLogDto>
{
    private static readonly List<HabitLog> _habitLogs = CreateHabitLogCommandHandler._habitLogs;
    private readonly IMapper _mapper;

    public UpdateHabitLogCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitLogDto> Handle(UpdateHabitLogCommand request, CancellationToken cancellationToken)
    {
        var habitLog = _habitLogs.FirstOrDefault(h => h.Id == request.Id);
        if (habitLog == null)
        {
            return Task.FromResult<HabitLogDto>(null!);
        }

        habitLog.HabitId = request.HabitId;
        habitLog.Date = request.Date;
        habitLog.Completed = request.Completed;

        return Task.FromResult(_mapper.Map<HabitLogDto>(habitLog));
    }
}
