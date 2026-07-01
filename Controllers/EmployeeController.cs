using EmployeeManagementPortal.DTO_s;
using EmployeeManagementPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            [FromBody] EmployeeInputDto employeeInputDto)
        {
            EmployeeResponseDTO employee = await _employeeService.CreateEmployee(employeeInputDto);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<EmployeeResponseDTO> employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            EmployeeResponseDTO response = await _employeeService.GetEmployeeById(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            await _employeeService.DeleteEmployeeById(id);
            return Ok(new { message = "Employee deleted successfully" });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id, [FromBody] EmployeeInputDto employeeInputDto)
        {
            EmployeeResponseDTO updatedEmployee = await _employeeService.UpdateEmployeeById(id, employeeInputDto);
            return Ok(updatedEmployee);
        }
    }
}