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
        public Service? Service { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }
}
