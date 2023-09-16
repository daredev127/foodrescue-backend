﻿using FoodRescue.Domain.Entities;
using FoodRescue.Domain.Repositories;
using FoodRescue.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace FoodRescue.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindByUsername(string username)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersBySearch(string search)
        {
            var users = await _dbContext.Users
                .Where(x => (string.IsNullOrEmpty(search) || x.Username.Contains(search)))
                .ToListAsync();
            return users;
        }
    }
}