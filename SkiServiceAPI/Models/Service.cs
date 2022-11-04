using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        [StringLength(50)]
        public string Service { get; set;}

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
