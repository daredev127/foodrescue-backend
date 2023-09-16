namespace FoodRescue.Application.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Organization { get; set; }
        public string OrgType { get; set; }
        public string Token { get; set; }
    }
}
