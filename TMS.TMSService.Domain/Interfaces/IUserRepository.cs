using System;
using TMS.TMSService.Domain.Entities;

namespace TMS.TMSService.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
		Task<User> AddUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task<bool> DeleteUserAsync(int userId);
    }
}

