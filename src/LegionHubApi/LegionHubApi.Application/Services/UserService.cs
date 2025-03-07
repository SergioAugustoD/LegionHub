using AutoMapper;
using LegionHubApi.Application.DTOs;
using LegionHubApi.Domain.Entities;
using LegionHubApi.Domain.Interfaces;

namespace LegionHubApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = HashPassword(password);
            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user != null)
            {
                _mapper.Map(userDto, user);
                await _userRepository.UpdateAsync(user);
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        private string HashPassword(string password)
        {
            return password; 
        }
}
