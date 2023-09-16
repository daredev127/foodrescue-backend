using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Features.Donation.AddDonation
{
    public class AddDonationCommand
    {
        public string FoodType { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public Guid UserId { get; set; }
    }
}
