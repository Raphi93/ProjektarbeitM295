
using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }




        //[StringLength(2550)]
        //public string? UserKey { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
