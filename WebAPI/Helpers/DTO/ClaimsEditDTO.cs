namespace WebAPI.Helpers.DTO
{
    public class ClaimsEditDTO
    {
        public int Id { get; set; }
        public string? EmployeeMail { get; set; }
        public DateTime Date { get; set; }
        public string? ReimbursementType { get; set; }
        public string? RequestedValue { get; set; }
        public string? ApprovedValue { get; set; }
        public string? Currency { get; set; }
        public string? RequestPhase { get; set; }
        public Boolean IsApproved { get; set; }
        public string? Reciept { get; set; }
    }
}
