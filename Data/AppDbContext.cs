using EmployeeManagementPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementPortal.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        // DbContext options are configured in Program.cs via AddDbContext;
        // OnConfiguring is not required and is intentionally omitted.

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
