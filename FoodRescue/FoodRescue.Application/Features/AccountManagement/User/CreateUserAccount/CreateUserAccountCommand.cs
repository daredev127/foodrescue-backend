namespace FoodRescue.Application.Features.AccountManagement.User.CreateUserAccount
{
    public class CreateUserAccountCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
