using MateMachine.LiveCoding.BackEnd.Api.Commands;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace MateMachine.LiveCoding.BackEnd.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Success)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCountryCommand { Id = id });
        if (!result.Success)
        {
            return NotFound(result.Error);
        }
        return Ok(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCountryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return NotFound(result.Error);
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCountryCommand { Id = id });
        if (!result.Success)
        {
            return NotFound(result.Error);
        }
        return NoContent();
    }
}


