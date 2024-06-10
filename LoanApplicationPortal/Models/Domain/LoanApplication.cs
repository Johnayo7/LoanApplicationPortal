using LoanApplicationPortal.Helpers;
using LoanApplicationPortal.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace LoanApplicationPortal.Models.Domain
{
    public class LoanApplication : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ("Name is required"))]
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$",
              ErrorMessage = "Every Name must start with a capital letter and contain only letters")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateOfBirth(ErrorMessage = "Date of Birth cannot be in the Future")]
        [CustomValidation(typeof(AddLoanApplication), "ValidateAge")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = ("Email is required"))]
        [EmailAddress(ErrorMessage = ("Invalid Email Format"))]
        public string Email { get; set; }

        [Required]
        public bool HomeOwner { get; set; }

        [Required]
        [Range(20000, 50000)]
        public decimal LoanRequestAmount { get; set; }

        public string Status { get; set; } = "In Progress";

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public static ValidationResult ValidateAge(DateTime dateOfBirth, ValidationContext context)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-18)
                ? ValidationResult.Success
                : new ValidationResult("Applicant must be at least 18 years old.");
        }
    }
}
