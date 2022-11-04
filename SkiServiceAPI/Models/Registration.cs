using System.ComponentModel.DataAnnotations;

namespace SkiServiceAPI.Models
{
    public class Registration
    {   
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }

        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int PriorityId { get; set; }

        public User User { get; set; }
        public Services Service { get; set; }
        public Priorities Priority { get; set; }
    }
}
