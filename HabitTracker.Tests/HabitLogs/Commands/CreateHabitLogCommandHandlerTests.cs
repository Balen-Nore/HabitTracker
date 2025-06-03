using NUnit.Framework;
using FluentAssertions;
using AutoMapper;
using HabitTracker.Application.HabitLogs.Commands;
using HabitTracker.Application.HabitLogs.Handlers;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Application.Mapping;
using System;
using System.Threading.Tasks;

namespace HabitTracker.Tests.HabitLogs.Commands;

[TestFixture]
public class CreateHabitLogCommandHandlerTests
{
    private IMapper _mapper = null!;
    private CreateHabitLogCommandHandler _handler = null!;

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
        _handler = new CreateHabitLogCommandHandler(_mapper);
    }

    [Test]
    public async Task Handle_ShouldReturnCreatedHabitLog()
    {
        var command = new CreateHabitLogCommand
        {
            HabitId = Guid.NewGuid(),
            Date = DateTime.Today,
            Completed = true
        };

        var result = await _handler.Handle(command, default);

        result.Should().NotBeNull();
        result.HabitId.Should().Be(command.HabitId);
        result.Completed.Should().BeTrue();
    }
}
