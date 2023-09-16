using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount;
using FoodRescue.Application.Features.Auth;
using FoodRescue.Domain.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Features.Donation.AddDonation
{
    public class AddDonationCommandHandler : IAddDonationCommandHandler
    {
        private readonly IDonationRepository _donationRepository;

        public AddDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResponseBaseDto> Handle(AddDonationCommand request)
        {
            var newDonation = request.Adapt<Domain.Entities.Donation>();
            newDonation.CreatedDate = DateTime.Now;
            newDonation.CreatedBy = "Admin";
            var donation = await _donationRepository.AddAsync(newDonation);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = donation };
        }
    }
}
