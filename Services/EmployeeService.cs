using EmployeeManagementPortal.DTO_s;
using EmployeeManagementPortal.Entities;
using EmployeeManagementPortal.Repositories;

namespace EmployeeManagementPortal.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponseDTO> CreateEmployee(
            EmployeeInputDto requestDto)
        {
            EmployeeEntity employee = new EmployeeEntity
            {
                Name = requestDto.Name,
                PhoneNumber = requestDto.PhoneNumber,
                Email = requestDto.Email,
                CompanyMailId = requestDto.CompanyMailId,
                Salary = requestDto.Salary,
                Department = requestDto.Department,
                Designation = requestDto.Designation,
                Address = requestDto.Address,
                City = requestDto.City
            };

            EmployeeResponseDTO createdEmployee = await _employeeRepository.CreateEmployee(employee);
            return createdEmployee;
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }
        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
           EmployeeResponseDTO response = await _employeeRepository.GetEmployeeById(id);
            return response;
        }

        public async Task DeleteEmployeeById(int id)
        {
            await _employeeRepository.DeleteEmployeeById(id);
        }

        public async Task<EmployeeResponseDTO> UpdateEmployeeById(int id, EmployeeInputDto employeeInputDto)
        {
            return await _employeeRepository.UpdateEmployeeById(id, employeeInputDto);
        }

        public async Task<EmployeeDocumentResponseDto> AddDocument(int employeeId, Microsoft.AspNetCore.Http.IFormFile file)
        {
            return await _employeeRepository.AddDocument(employeeId, file);
        }

        public async Task<IEnumerable<EmployeeDocumentResponseDto>> GetDocumentsByEmployeeId(int employeeId)
        {
            return await _employeeRepository.GetDocumentsByEmployeeId(employeeId);
        }

        public async Task<(byte[] Data, string FileName, string ContentType)> GetDocumentData(int documentId)
        {
            return await _employeeRepository.GetDocumentData(documentId);
        }

        public async Task DeleteDocumentById(int documentId)
        {
            await _employeeRepository.DeleteDocumentById(documentId);
        }
    }
}