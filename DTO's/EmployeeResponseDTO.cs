namespace EmployeeManagementPortal.DTO_s
{
    public class EmployeeResponseDTO
    {
              public  int Id { get; set; }
              public required string Name { get; set; }

            public required string PhoneNumber { get; set; }
            public  required string Company { get; set; }
            public double Salary { get; set; }

    }
}
