using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string ?phone {  get; set; }

        public List<Guest> ?guests { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
