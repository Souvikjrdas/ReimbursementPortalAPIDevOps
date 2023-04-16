using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class PendingRequests
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string? EmployeeMail { get; set; }

        [Required]
        public string? ReimbursementType { get; set; }

        [Required]
        public double RequestedValue { get; set; }

        [Required]
        public string? Currency { get; set; }
    }
}
