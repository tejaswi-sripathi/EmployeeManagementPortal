using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.DTO_s;
using EmployeeManagementPortal.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementPortal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDocumentResponseDto> AddDocument(int employeeId, IFormFile file)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            var doc = new EmployeeDocument
            {
                EmployeeId = employeeId,
                FileName = file.FileName,
                ContentType = file.ContentType ?? "application/octet-stream",
                Data = ms.ToArray(),
                UploadedAt = DateTime.UtcNow
            };

            await _context.EmployeeDocuments.AddAsync(doc);
            await _context.SaveChangesAsync();

            return new EmployeeDocumentResponseDto
            {
                Id = doc.Id,
                FileName = doc.FileName,
                ContentType = doc.ContentType,
                UploadedAt = doc.UploadedAt
            };
        }

        public async Task<IEnumerable<EmployeeDocumentResponseDto>> GetDocumentsByEmployeeId(int employeeId)
        {
            return await _context.EmployeeDocuments
                .Where(d => d.EmployeeId == employeeId)
                .Select(d => new EmployeeDocumentResponseDto
                {
                    Id = d.Id,
                    FileName = d.FileName,
                    ContentType = d.ContentType,
                    UploadedAt = d.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<(byte[] Data, string FileName, string ContentType)> GetDocumentData(int documentId)
        {
            var doc = await _context.EmployeeDocuments.FindAsync(documentId);
            if (doc == null)
                throw new KeyNotFoundException("Document not found");

            return (doc.Data, doc.FileName, doc.ContentType);
        }

        public async Task DeleteDocumentById(int documentId)
        {
            var doc = await _context.EmployeeDocuments.FindAsync(documentId);
            if (doc == null)
                throw new KeyNotFoundException("Document not found");

            _context.EmployeeDocuments.Remove(doc);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeResponseDTO> CreateEmployee(
            EmployeeEntity employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                CompanyMailId = employee.CompanyMailId,
                Department = employee.Department,
                Designation = employee.Designation,
                Address = employee.Address,
                City = employee.City,
                Salary = employee.Salary,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees.Select(e => new EmployeeResponseDTO
            {
                Id = e.Id,
                Name = e.Name,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                CompanyMailId = e.CompanyMailId,
                Department = e.Department,
                Designation = e.Designation,
                Address = e.Address,
                City = e.City,
                Salary = e.Salary,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            });
        }
        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
               throw new KeyNotFoundException("Employee not found"); // or throw an exception, depending on your error handling strategy
            }
            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                CompanyMailId = employee.CompanyMailId,
                Department = employee.Department,
                Designation = employee.Designation,
                Address = employee.Address,
                City = employee.City,
                Salary = employee.Salary,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
        public async Task DeleteEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Employee with the given id not found");
            }
        }

        public async Task<EmployeeResponseDTO> UpdateEmployeeById(int id, EmployeeInputDto employeeInputDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            employee.Name = employeeInputDto.Name;
            employee.PhoneNumber = employeeInputDto.PhoneNumber;
            employee.Email = employeeInputDto.Email;
            employee.CompanyMailId = employeeInputDto.CompanyMailId;
            employee.Salary = employeeInputDto.Salary;
            employee.Department = employeeInputDto.Department;
            employee.Designation = employeeInputDto.Designation;
            employee.Address = employeeInputDto.Address;
            employee.City = employeeInputDto.City;
            employee.UpdatedAt = DateTime.UtcNow;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                CompanyMailId = employee.CompanyMailId,
                Department = employee.Department,
                Designation = employee.Designation,
                Address = employee.Address,
                City = employee.City,
                Salary = employee.Salary,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
    }
}