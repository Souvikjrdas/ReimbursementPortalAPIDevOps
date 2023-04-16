namespace WebAPI.Helpers.DTO
{
    public class DeclineDTO
    {
        public DateTime Date { get; set; }

        public string? EmployeeMail { get; set; }

        public string? ReimbursementType { get; set; }

        public string? RequestedValue { get; set; }

        public string? Currency { get; set; }

        public string? InternalNotes { get; set; }
    }
}
