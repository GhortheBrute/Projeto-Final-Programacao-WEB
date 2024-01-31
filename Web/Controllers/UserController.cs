using Application.Services;
using Domain.Options;
using Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Web.Filters;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
[CustomActionFilter]
[ExceptionFilter]
public class UserController : ControllerBase
{
    private readonly ClassOptions _config;
    private readonly IUserService _service;

    public UserController(IUserService service, IOptions<ClassOptions> config ) 
    {
        _service = service;
        _config = config.Value; 
    }

    [HttpGet]
    public IActionResult List([FromQuery] UserFilters filters)
    {
        var users = _service.List();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _service.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BaseUserRequest user)
    {
        var newUser = _service.Create(user);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateUserRequest user)
    {
        user.Id = id;
        var updatedUser = _service.Update(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}

public class UserFilters
{
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? OrderBy { get; set; }
}

