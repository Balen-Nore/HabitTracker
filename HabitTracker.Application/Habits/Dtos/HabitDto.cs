namespace HabitTracker.Application.Habits.Dtos;

public class HabitDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TargetPerWeek { get; set; }
    public DateTime StartDate { get; set; }
}
