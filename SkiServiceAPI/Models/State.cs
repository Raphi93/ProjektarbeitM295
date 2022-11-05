namespace SkiServiceAPI.Models
{
    public class State
    {
        public int? StateId { get; set; }
        public string? Status { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
