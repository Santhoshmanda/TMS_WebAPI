using System;
using TMS.TMSService.Application.DTOs;
using TMS.TMSService.Domain.Entities;

namespace TMS.TMSService.Application.Interfaces
{
	public interface IUserService
	{
        Task<IEnumerable<UserDto>> GetllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<UserDto> AddUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(int userId);
    }
}

