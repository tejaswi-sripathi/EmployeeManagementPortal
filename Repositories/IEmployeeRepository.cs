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

        Task<EmployeeDocumentResponseDto> AddDocument(int employeeId, Microsoft.AspNetCore.Http.IFormFile file);
        // Keep single-file repository method; service handles batching
        Task<IEnumerable<EmployeeDocumentResponseDto>> GetDocumentsByEmployeeId(int employeeId);
        Task<(byte[] Data, string FileName, string ContentType)> GetDocumentData(int documentId);
        Task DeleteDocumentById(int documentId);
    }
}