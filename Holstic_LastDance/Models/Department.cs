using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Models
{
    public class Department
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string ?Description   { get; set; }

        public List<Staff> ?Staffs { get; set; }
    }
}
