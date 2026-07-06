namespace EmployeeManagementPortal.DTO_s
{
    public class EmployeeDocumentResponseDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public DateTime UploadedAt { get; set; }
    }
}
