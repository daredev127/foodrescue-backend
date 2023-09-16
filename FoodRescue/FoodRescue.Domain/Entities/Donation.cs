using FoodRescue.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Domain.Entities
{
    public class Donation: EntityBase
    {
        public string FoodType { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
