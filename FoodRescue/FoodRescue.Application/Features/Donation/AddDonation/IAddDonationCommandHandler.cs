using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Features.Donation.AddDonation
{
    public interface IAddDonationCommandHandler
    {
        Task<ResponseBaseDto> Handle(AddDonationCommand request);
    }
}
