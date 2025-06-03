using MediatR;
using AutoMapper;
using HabitTracker.Application.HabitLogs.Commands;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HabitTracker.Application.HabitLogs.Handlers;

public class CreateHabitLogCommandHandler : IRequestHandler<CreateHabitLogCommand, HabitLogDto>
{
    public static readonly List<HabitLog> _habitLogs = new List<HabitLog>();
    private readonly IMapper _mapper;

    public CreateHabitLogCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<HabitLogDto> Handle(CreateHabitLogCommand request, CancellationToken cancellationToken)
    {
        var habitLog = new HabitLog
        {
            Id = Guid.NewGuid(),
            HabitId = request.HabitId,
            Date = request.Date,
            Completed = request.Completed
        };

        _habitLogs.Add(habitLog);

        return Task.FromResult(_mapper.Map<HabitLogDto>(habitLog));
    }
}
