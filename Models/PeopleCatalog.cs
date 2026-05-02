using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biographic.Models
{
    public class PeopleCatalog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(100,  ErrorMessage = "Името на каталога трябва да бъде до 100 символа")]
        public required string Name { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}
