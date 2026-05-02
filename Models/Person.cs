using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biographic.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Името на личността трябва да бъде до 100 символа.")]
        public required string Name { get; set; }

        public string? ProfileImage { get; set; }

        [NotMapped]
        public IFormFile? ProfileImageFile { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        [Required]
        public int ProfessionId { get; set; }

        [ForeignKey("ProfessionId")]
        public Profession? Profession { get; set; }

        public string Biography { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на раждане")]
        [StartDateBeforeCurrentDate]
        public DateTime StartDate { get; set; }

        [Display(Name = "Починал ли е?")]
        public bool IsDead { get; set; } = false;

        [DataType(DataType.Date)]
        [Display(Name = "Дата на смъртта")]
        [EndDateValidation]
        public DateTime? EndDate { get; set; }

        public List<PeopleCatalog> PeopleCatalogs { get; set; } = new();

        public class StartDateBeforeCurrentDateAttribute : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value is DateTime startDate && startDate >= DateTime.Now.Date)
                {
                    return new ValidationResult("Датата на раждане трябва да бъде в миналото.");
                }
                return ValidationResult.Success;
            }
        }

        public class EndDateValidation : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                var person = (Person)validationContext.ObjectInstance;

                if (person.IsDead)
                {
                    if (!person.EndDate.HasValue)
                    {
                        return new ValidationResult("Ако личността е починала, трябва да има дата на смъртта.");
                    }

                    if (person.EndDate <= person.StartDate)
                    {
                        return new ValidationResult("Датата на смъртта трябва да бъде след датата на раждане.");
                    }

                    if (person.EndDate >= DateTime.Now.Date)
                    {
                        return new ValidationResult("Датата на смъртта трябва да бъде в миналото.");
                    }
                }
                else
                {
                    if (person.EndDate.HasValue)
                    {
                        return new ValidationResult("Не трябва да има дата на смъртта ако личността е жива.");
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}
