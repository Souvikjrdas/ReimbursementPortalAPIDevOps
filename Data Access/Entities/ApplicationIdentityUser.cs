using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class ApplicationIdentityUser : IdentityUser
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        [StringLength(10,MinimumLength = 10)]
        public string? PAN { get; set; }

        [Required]
        public string? Bank { get; set; }

        [Required]
        [MaxLength(12)]
        [MinLength(12)]
        public long AccountNo { get; set; }
    }
}
