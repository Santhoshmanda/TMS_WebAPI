using System;
using Microsoft.EntityFrameworkCore;
using TMS.TMSService.Domain.Entities;
using TMS.TMSService.Domain.Interfaces;
using TMS.TMSService.Infrastructure.Persistance;

namespace TMS.TMSService.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly TMSContext _tmsContext;
		public UserRepository(TMSContext tmsContext)
		{
            _tmsContext = tmsContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
           _tmsContext.Users.Add(user);
            await _tmsContext.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userEntity =  await _tmsContext.Users.FindAsync(userId);
            if (userEntity != null)
            {
                _tmsContext.Users.Remove(userEntity);
                await _tmsContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<User>> GetllUsersAsync()
        {
            return await _tmsContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _tmsContext.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
             _tmsContext.Users.Update(user);
            await _tmsContext.SaveChangesAsync();
        }
    }
}

