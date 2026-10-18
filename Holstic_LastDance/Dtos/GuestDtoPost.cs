using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Dtos
{
    public class GuestDtoPost
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public List<int> ?StaffIds { get; set; }

        public RoomDtoPost ?Room { get; set; }
    }

    public class GuestDtoGet
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public List<StaffDtoGetguest>? Staffs { get; set; }

        public RoomDtoGet ?Roomm { get; set; }
    }
}
