using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EmployeeManagementPortal.DTO_s
{
    public class EmployeeInputDto
    {
        public required string Name { get; set; }

        [Required]
        [RegularExpression(@"^\+?[0-9]{7,15}$", ErrorMessage = "Enter a valid phone number.")]
        public required string PhoneNumber { get; set; }

        public required string Company { get; set; }
        public double Salary { get; set; }

    }
}
