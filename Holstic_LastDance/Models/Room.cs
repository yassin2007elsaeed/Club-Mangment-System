using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public int GuestId { get; set; }
        public Guest ?Guest { get; set; }
    }
}
