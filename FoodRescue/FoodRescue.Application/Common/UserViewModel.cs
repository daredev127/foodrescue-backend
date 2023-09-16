namespace FoodRescue.Application.Common
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Organization { get; set; }
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
