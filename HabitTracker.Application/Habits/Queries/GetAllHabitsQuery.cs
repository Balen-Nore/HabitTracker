using MediatR;
using HabitTracker.Application.Habits.Dtos;
using System.Collections.Generic;

namespace HabitTracker.Application.Habits.Queries;

public class GetAllHabitsQuery : IRequest<List<HabitDto>>
{
}
