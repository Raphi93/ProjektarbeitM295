using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Registration
    {   
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? EMail { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? PickupDate { get; set; }
        public string? Kommentar { get; set; }

        public int? UserId { get; set; }
        public int? ServiceId { get; set; }
        public int? PriorityId { get; set; }
        public int? Status { get; set; }


        public User? User { get; set; }
        

        public Services? Service { get; set; }
        public Priorities? Priority { get; set; }
        public State? State { get; set; }
    }
}
