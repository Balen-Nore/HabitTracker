using MediatR;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Application.Habits.Commands;
using HabitTracker.Application.Habits.Dtos;
using HabitTracker.Application.Habits.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HabitsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<HabitDto>> Create([FromBody] CreateHabitCommand command)
    {
        var habit = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = habit.Id }, habit);
    }

    [HttpGet]
    public async Task<ActionResult<List<HabitDto>>> GetAll()
    {
        var habits = await _mediator.Send(new GetAllHabitsQuery());
        return Ok(habits);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetById(Guid id)
    {
        var habit = await _mediator.Send(new GetHabitByIdQuery(id));
        if (habit == null) return NotFound();
        return Ok(habit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<HabitDto>> Update(Guid id, [FromBody] UpdateHabitCommand command)
    {
        if (id != command.Id) return BadRequest("Id mismatch");
        var updatedHabit = await _mediator.Send(command);
        if (updatedHabit == null) return NotFound();
        return Ok(updatedHabit);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteHabitCommand { Id = id });
        if (!result) return NotFound();
        return NoContent();
    }
}