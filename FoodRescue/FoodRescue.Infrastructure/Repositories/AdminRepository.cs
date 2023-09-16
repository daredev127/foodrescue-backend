using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class AdminRepository : RepositoryBase<AdminUser>, IAdminRepository
    {
        public AdminRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<AdminUser> FindByUsername(string username)
        {
            var adminUser = await _dbContext.AdminUsers
                .FirstOrDefaultAsync(x => x.Username == username);
            return adminUser;
        }

        public async Task<IEnumerable<AdminUser>> GetUsersBySearchAndStatus(string search, string status)
        {
            var adminUsers = await _dbContext.AdminUsers
                .Where(x => (string.IsNullOrEmpty(search) || (x.Username.Contains(search) || x.Name.Contains(search)))
                    && (string.IsNullOrEmpty(status) || x.Status == status))
                .ToListAsync();
            return adminUsers;
        }
    }
}
