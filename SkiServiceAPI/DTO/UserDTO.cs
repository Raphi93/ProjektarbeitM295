using System.Text.Json.Serialization;

namespace SkiServiceAPI.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}
