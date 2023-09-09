using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController, Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Get(string query)
    {
        var skills = _service.GetAll(query);
        return Ok(skills);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var skill = _service.GetById(id);
        if (skill == null)
        {
            return NotFound();
        }
        return Ok(skill);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] NewUserInputModel inputModel)
    {
        var id = _service.Create(inputModel);
        return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
    {
        if (id != inputModel.Id)
        {
            return BadRequest();
        }
        _service.Update(inputModel);
        return NoContent();
    }
}