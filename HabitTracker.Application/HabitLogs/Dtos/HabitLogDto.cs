using System;

namespace HabitTracker.Application.HabitLogs.Dtos;

public class HabitLogDto
{
    public Guid Id { get; set; }
    public Guid HabitId { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }
}
