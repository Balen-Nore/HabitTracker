using AutoMapper;
using HabitTracker.Application.Habits.Commands;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Application.HabitLogs.Commands;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Habit
        CreateMap<Habit, HabitDto>().ReverseMap();
        CreateMap<CreateHabitCommand, Habit>();
        CreateMap<UpdateHabitCommand, Habit>();

        // HabitLog
        CreateMap<HabitLog, HabitLogDto>().ReverseMap();
        CreateMap<CreateHabitLogCommand, HabitLog>();
        CreateMap<UpdateHabitLogCommand, HabitLog>();
    }
}
