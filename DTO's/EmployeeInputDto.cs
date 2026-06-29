using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EmployeeManagementPortal.DTO_s
{
    public class EmployeeInputDto
    {
        public required string Name { get; set; }
        
        public required string PhoneNumber { get; set; }
        public required string Company { get; set; }
        public double Salary { get; set; }

    }
}
