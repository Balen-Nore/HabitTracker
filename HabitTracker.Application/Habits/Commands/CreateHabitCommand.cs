using MediatR;
using HabitTracker.Application.Habits.Dtos;

namespace HabitTracker.Application.Habits.Commands;

public class CreateHabitCommand : IRequest<HabitDto>
{
    public string Name { get; set; } = string.Empty;
    public int TargetPerWeek { get; set; }
    public DateTime StartDate { get; set; }
}
