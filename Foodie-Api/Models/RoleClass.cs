using System.Text.Json.Serialization;

namespace Foodie_Api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleClass
    {
        Admin = 1,
        User = 2,
        Moderator = 3
    }
}