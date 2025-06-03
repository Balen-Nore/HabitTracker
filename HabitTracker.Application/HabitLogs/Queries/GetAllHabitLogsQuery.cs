using MediatR;
using HabitTracker.Application.HabitLogs.Dtos;
using System.Collections.Generic;

namespace HabitTracker.Application.HabitLogs.Queries;

public class GetAllHabitLogsQuery : IRequest<List<HabitLogDto>>
{
}
