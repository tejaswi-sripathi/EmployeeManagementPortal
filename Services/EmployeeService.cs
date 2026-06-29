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
                Company = requestDto.Company,
                Salary = requestDto.Salary
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
    }
}