using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Status
    {
        [Key]
        public int? StatusId { get; set; }

        public string? StatusName { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
