using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount;
using FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodRescue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetUserAccountsQueryHandler _getUserAccountsQueryHandler;
        private readonly ICreateUserAccountCommandHandler _createUserAccountCommandHandler;

        public UserController(
            IGetUserAccountsQueryHandler getUserAccountsQueryHandler,
            ICreateUserAccountCommandHandler createUserAccountCommandHandler
        )
        {
            _getUserAccountsQueryHandler = getUserAccountsQueryHandler;
            _createUserAccountCommandHandler = createUserAccountCommandHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetUserAccounts([FromQuery] string search)
        {
            var query = new GetUserAccountsQuery(search);
            var users = await _getUserAccountsQueryHandler.Handle(query);
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> CreateUserAccount([FromBody] CreateUserAccountCommand request)
        {
            var result = await _createUserAccountCommandHandler.Handle(request);
            return Ok(result);
        }
    }
}
