using MediatR;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Application.HabitLogs.Commands;
using HabitTracker.Application.HabitLogs.Dtos;
using HabitTracker.Application.HabitLogs.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HabitLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<HabitLogDto>> Create([FromBody] CreateHabitLogCommand command)
    {
        var habitLog = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = habitLog.Id }, habitLog);
    }

    [HttpGet]
    public async Task<ActionResult<List<HabitLogDto>>> GetAll()
    {
        var habitLogs = await _mediator.Send(new GetAllHabitLogsQuery());
        return Ok(habitLogs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitLogDto>> GetById(Guid id)
    {
        var habitLog = await _mediator.Send(new GetHabitLogByIdQuery(id));
        if (habitLog == null) return NotFound();
        return Ok(habitLog);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<HabitLogDto>> Update(Guid id, [FromBody] UpdateHabitLogCommand command)
    {
        if (id != command.Id) return BadRequest("Id mismatch");
        var updatedHabitLog = await _mediator.Send(command);
        if (updatedHabitLog == null) return NotFound();
        return Ok(updatedHabitLog);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteHabitLogCommand { Id = id });
        if (!result) return NotFound();
        return NoContent();
    }
}