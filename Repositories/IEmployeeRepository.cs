using EmployeeManagementPortal.DTO_s;
using EmployeeManagementPortal.Entities;

namespace EmployeeManagementPortal.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeResponseDTO> CreateEmployee(
            EmployeeEntity employee);
        Task DeleteEmployeeById(int id);
        Task<IEnumerable<EmployeeResponseDTO>> GetAllEmployees();
        Task<EmployeeResponseDTO> GetEmployeeById(int id);
        Task<EmployeeResponseDTO> UpdateEmployeeById(int id, EmployeeInputDto employeeInputDto);
    }
}