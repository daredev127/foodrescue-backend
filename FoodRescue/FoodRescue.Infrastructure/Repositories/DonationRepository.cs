using FoodRescue.Domain.Entities;
using FoodRescue.Domain.Repositories;
using FoodRescue.Infrastructure.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Infrastructure.Repositories
{
    public class DonationRepository: RepositoryBase<Donation>, IDonationRepository
    {
        public DonationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
