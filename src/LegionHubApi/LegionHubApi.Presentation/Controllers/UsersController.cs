using System;
using LegionHubApi.Application.DTOs;
using LegionHubApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegionHubApi.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto, [FromQuery] string password)
    {
        var createdUser = await _userService.CreateUserAsync(userDto, password);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
    {
        userDto.Id = id;
        await _userService.UpdateUserAsync(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}
