using System.Text.Json.Serialization;

namespace SkiServiceAPI.DTO
{
    public class StatusDTO
    {
        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }
        [JsonPropertyName("status")]
        public string StatusName { get; set; }
        public List<RegistrationDTO> Registration { get; set; } = new List<RegistrationDTO>();
    }
}
