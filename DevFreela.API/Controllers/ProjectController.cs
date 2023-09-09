using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController, Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _service.GetAll(query);
        return Ok(projects);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _service.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel command)
    {
        if (command.Title.Length > 50)
        {
            return BadRequest();
        }
        
        var id = _service.Create(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel command)
    {
        _service.Update(command);
        return NoContent();
    }
}