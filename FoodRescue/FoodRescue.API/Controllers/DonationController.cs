using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount;
using FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts;
using FoodRescue.Application.Features.Donation.AddDonation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodRescue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IAddDonationCommandHandler _addDonationCommandHandler;

        public DonationController(IAddDonationCommandHandler addDonationCommandHandler)
        {
            _addDonationCommandHandler = addDonationCommandHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> AddDonation([FromBody] AddDonationCommand request)
        {
            var result = await _addDonationCommandHandler.Handle(request);
            return Ok(result);
        }
    }
}
