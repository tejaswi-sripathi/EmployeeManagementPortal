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

        [HttpPost("{id}/documents")]
        public async Task<IActionResult> UploadDocument(int id, IFormFile file)
        {
            var doc = await _employeeService.AddDocument(id, file);
            return Ok(doc);
        }

        [HttpGet("{id}/documents")]
        public async Task<IActionResult> GetDocuments(int id)
        {
            var docs = await _employeeService.GetDocumentsByEmployeeId(id);
            return Ok(docs);
        }

        [HttpGet("documents/{docId}")]
        public async Task<IActionResult> DownloadDocument(int docId)
        {
            var (data, fileName, contentType) = await _employeeService.GetDocumentData(docId);
            return File(data, contentType, fileName);
        }

        [HttpDelete("documents/{docId}")]
        public async Task<IActionResult> DeleteDocument(int docId)
        {
            await _employeeService.DeleteDocumentById(docId);
            return NoContent();
        }
    }
}