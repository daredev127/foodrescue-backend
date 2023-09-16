using FoodRescue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Domain.Repositories
{
    public interface IDonationRepository:IAsyncRepository<Donation>
    {
    }
}
