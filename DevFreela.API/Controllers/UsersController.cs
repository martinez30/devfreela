using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Queries.GetAllUserQuery;
using DevFreela.Application.Queries.GetUserByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController, Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var skills = await _mediator.Send(new GetAllUserQuery());
        return Ok(skills);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var skill = await _mediator.Send(new GetUserByIdQuery(id));
        if (skill == null)
        {
            return NotFound();
        }
        return Ok(skill);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }
}