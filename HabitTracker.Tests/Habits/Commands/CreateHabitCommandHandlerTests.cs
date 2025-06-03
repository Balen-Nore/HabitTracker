using NUnit.Framework;
using FluentAssertions;
using AutoMapper;
using HabitTracker.Application.Habits.Commands;
using HabitTracker.Application.Habits.Handlers;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Application.Mapping;
using System;
using System.Threading.Tasks;

namespace HabitTracker.Tests.Habits.Commands;

[TestFixture]
public class CreateHabitCommandHandlerTests
{
    private IMapper _mapper = null!;
    private CreateHabitCommandHandler _handler = null!;

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
        _handler = new CreateHabitCommandHandler(_mapper);
    }

    [Test]
    public async Task Handle_ShouldReturnCreatedHabit()
    {
        var command = new CreateHabitCommand
        {
            Name = "Test Habit",
            TargetPerWeek = 5,
            StartDate = DateTime.UtcNow
        };

        var result = await _handler.Handle(command, default);

        result.Should().NotBeNull();
        result.Name.Should().Be(command.Name);
        result.TargetPerWeek.Should().Be(command.TargetPerWeek);
        result.Id.Should().NotBeEmpty();
    }
}
