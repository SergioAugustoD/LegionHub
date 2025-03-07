using System;
using LegionHubApi.Application.DTOs;

namespace LegionHubApi.Application.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> CreateUserAsync(UserDto userDto, string password);
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(Guid id);
}
