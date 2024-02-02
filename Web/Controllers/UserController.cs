using Application.Services;
using Domain.Options;
using Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Filters;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Adm")]
public class UserController : ControllerBase
{
    private readonly TokenOptions _config;
    private readonly IUserService _service;

    public UserController(IUserService service, IOptions<TokenOptions> config ) 
    {
        _service = service;
        _config = config.Value; 
    }

    [HttpGet]
    public IActionResult List()
    {
        var users = _service.List();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = _service.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
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
        var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        _service.Delete(id);
        return NoContent();
    }
}

