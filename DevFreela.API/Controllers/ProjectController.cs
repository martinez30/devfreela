using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjectsQuery;
using DevFreela.Application.Queries.GetProjectByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController, Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var projects = await _mediator.Send(new GetAllProjectsQuery(query));
        return Ok(projects);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _mediator.Send(new GetProjectByIdQuery(id));

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        if (command.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPost("{id}/comment")]
    public async Task<IActionResult> PostCommment(int id, [FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}