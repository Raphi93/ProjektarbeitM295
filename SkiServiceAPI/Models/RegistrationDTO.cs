using System.Text.Json.Serialization;

namespace SkiServiceAPI.Models
{
    public class RegistrationDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? EMail { get; set; } 

        [JsonPropertyName("phone")]
        public string? Phone { get; set; } 

        [JsonPropertyName("priority")]
        public string? Priority { get; set; } //auserhalb1 fk

        [JsonPropertyName("service")]
        public string? Service { get; set; } //auserhalb2 fk

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("pickup_date")]
        public DateTime PickupDate { get; set; }
    }
}
