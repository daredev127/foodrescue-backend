namespace FoodRescue.Application.Features.AccountManagement.User.GetUserAccounts
{
    public class GetUserAccountsQuery
    {
        public string Search { get; set; }

        public GetUserAccountsQuery(string search)
        {
            Search = search;
        }
    }
}
