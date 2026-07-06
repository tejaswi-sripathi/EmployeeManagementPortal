namespace EmployeeManagementPortal.DTO_s
{
    public class EmployeeResponseDTO
    {
              public  int Id { get; set; }
              public required string Name { get; set; }

            public required string PhoneNumber { get; set; }
            public required string Email { get; set; }
            public required string CompanyMailId { get; set; }
            public required string Department { get; set; }
            public required string Designation { get; set; }
            public required string Address { get; set; }
            public required string City { get; set; }
            public double Salary { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

    }
}
