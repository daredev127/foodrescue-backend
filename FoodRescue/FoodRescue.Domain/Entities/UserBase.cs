using FoodRescue.Domain.Entities;
using FoodRescue.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace FoodRescue.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
