using DevFreela.Application.Queries.GetAllSkillQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController, Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var skills = await _mediator.Send(new GetAllSkillQuery());
        return Ok(skills);
    }
}