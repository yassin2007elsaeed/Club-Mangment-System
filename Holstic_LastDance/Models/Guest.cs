using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Models
{
    public class Guest
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public List<Staff> ?Staffs { get; set; }

        public Room ?Room { get; set; }
    }
}
