using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biographic.Models
{
    public class UserCatalogs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public required ApplicationUser ApplicationUser { get; set; }

        public List<PeopleCatalog> PeopleCatalogs { get; set; } = new List<PeopleCatalog>();
    }
}
