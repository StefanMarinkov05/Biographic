using System.ComponentModel.DataAnnotations;

namespace Biographic.Models
{
    public class Profession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
