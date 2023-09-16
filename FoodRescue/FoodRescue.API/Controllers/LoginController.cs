using FoodRescue.Application.Dtos;
using FoodRescue.Application.Features.Auth.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodRescue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginCommandHandler _loginCommandHandler;

        public LoginController(
            ILoginCommandHandler loginCommandHandler)
        {
            _loginCommandHandler = loginCommandHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> Login([FromBody] LoginCommand request)
        {
            var response = await _loginCommandHandler.Handle(request);
            return Ok(response);
        }
    }
}
