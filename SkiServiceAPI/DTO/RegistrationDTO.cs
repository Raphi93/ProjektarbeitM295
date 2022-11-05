using System.Text.Json.Serialization;

namespace SkiServiceAPI.DTO
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
        public string? Priority { get; set; }

        [JsonPropertyName("service")]
        public string? Service { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("kommentar")]
        public string? Kommentar { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("pickup_date")]
        public DateTime PickupDate { get; set; }
    }
}
