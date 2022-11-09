using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Service
    {
        [Key]
        public int? ServiceId { get; set; }
        [StringLength(50)]
        public string? ServiceName { get; set;}
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
