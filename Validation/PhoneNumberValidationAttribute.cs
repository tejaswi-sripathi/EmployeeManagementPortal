using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmployeeManagementPortal.Validation
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
            {
                return new ValidationResult("Phone number is required.");
            }

            // Extract digits
            var digits = new string(str.Where(char.IsDigit).ToArray());

            // Accept numbers with between 7 and 15 digits (adjustable)
            if (digits.Length < 7 || digits.Length > 15)
            {
                return new ValidationResult("Phone number must contain between 7 and 15 digits.");
            }

            // Reject if all digits are zeros
            if (digits.All(c => c == '0'))
            {
                return new ValidationResult("Phone number cannot be all zeros.");
            }

            return ValidationResult.Success;
        }
    }
}
