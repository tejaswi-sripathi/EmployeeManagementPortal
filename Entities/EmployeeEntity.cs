using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EmployeeManagementPortal.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email {  get; set; }
        public required string CompanyMailId { get; set; }
        public double Salary { get; set; }
        public required string Department { get; set; }
        public required string Designation { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
       

    }
}
