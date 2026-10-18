using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Dtos
{
    public class StaffDtos
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string? phone { get; set; }

        public int DepartmentId { get; set; }
    }
    public class StaffDtoGet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string? phone { get; set; }

        public DepartmentDtoGet Department { get; set; }
    }

   public class StaffDtoGetguest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string? phone { get; set; }
    }
}
