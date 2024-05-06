using AutoMapper;
using TMS.TMSService.Application.DTOs;
using TMS.TMSService.Application.Interfaces;
using TMS.TMSService.Domain.Entities;
using TMS.TMSService.Domain.Interfaces;

namespace TMS.TMSService.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
		{
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<UserDto> AddUserAsync(UserDto user)
        {
             var userEntity=await _userRepository.AddUserAsync(_mapper.Map<User>(user));
             return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetllUsersAsync()
        {
            var userEntities= await _userRepository.GetllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            if (userEntity != null)
            {
                return _mapper.Map<UserDto>(userEntity);
            }
            return null;
        }

        public async Task UpdateUserAsync(UserDto user)
        {
            await _userRepository.UpdateUserAsync(_mapper.Map<User>(user));
        }
    }
}

