using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.DTO_s;
using EmployeeManagementPortal.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementPortal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
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
                Company = employee.Company,
                Salary = employee.Salary
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
                Company = e.Company,
                Salary = e.Salary
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
                Company = employee.Company,
                Salary = employee.Salary
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
            employee.Company = employeeInputDto.Company;
            employee.Salary = employeeInputDto.Salary;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Company = employee.Company,
                Salary = employee.Salary
            };
        }
    }
}