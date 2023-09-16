namespace FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount
{
    public class CreateUserAccountCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OrganizationId { get; set; }
    }
}
