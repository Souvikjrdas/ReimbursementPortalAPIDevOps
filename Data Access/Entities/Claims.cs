using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class Claims
    {

        public int Id { get; set; }

        [Required]
        public string? EmployeeMail { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string? ReimbursementType { get; set; }

        [Required]
        public string? RequestedValue { get; set; }
        public string? ApprovedValue { get; set; }

        [Required]
        public string? Currency { get; set; }

        [Required]
        public string? RequestPhase { get; set; }

        [Required]
        public Boolean IsApproved { get; set; }

        public string? Reciept { get; set; }

    }
}
