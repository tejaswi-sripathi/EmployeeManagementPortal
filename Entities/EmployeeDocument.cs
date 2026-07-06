using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementPortal.Entities
{
    public class EmployeeDocument
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public EmployeeEntity? Employee { get; set; }
    }
}
