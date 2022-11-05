
using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string? UserName { get; set; }

        [StringLength(2550)]
        public string? Password { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
