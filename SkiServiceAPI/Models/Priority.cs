using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Priority
    {
        [Key]   
        public int PriorityId { get; set; }

        [StringLength(50)]
        public string? PriorityName { get; set;}

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
