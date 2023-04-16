namespace WebAPI.Helpers.DTO
{
    public class ApprovedDTO
    {
        public DateTime Date { get; set; }

        public string? EmployeeMail { get; set; }

        public string? ReimbursementType { get; set; }

        public string? RequestedValue { get; set; }

        public string? ApprovedValue { get; set; }

        public string? ApprovedBy { get; set; }

        public string? Currency { get; set; }

        public string? InternalNotes { get; set; }
    }
}
