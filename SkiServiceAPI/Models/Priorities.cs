using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Priorities
    {
        [Key]   
        public int PriorityId { get; set; }

        [StringLength(50)]
        public string? Priority { get; set;}

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
