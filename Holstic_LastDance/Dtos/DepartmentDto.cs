using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Dtos
{
    public class DepartmentDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class DepartmentDtoGet
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
