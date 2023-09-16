using FoodRescue.Application.Dtos;
using FoodRescue.Domain.Constants;
using FoodRescue.Domain.Repositories;

namespace FoodRescue.Application.Features.Auth.User
{
    public class LoginCommandHandler : ILoginCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordUtils _passwordUtil;
        private readonly IJwtUtils _jwtUtils;
        public LoginCommandHandler(IUserRepository userRepository, IPasswordUtils passwordUtil, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _passwordUtil = passwordUtil;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResponseBaseDto> Handle(LoginCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };

            var user = await _userRepository.FindByUsername(request.Username);
            if (user == null || !_passwordUtil.Validate(user.Password, request.Password))
            {
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };
            }

            var token = _jwtUtils.GenerateJwtToken(user.Username);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new LoginResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Token = token
                }
            };
        }
    }
}
