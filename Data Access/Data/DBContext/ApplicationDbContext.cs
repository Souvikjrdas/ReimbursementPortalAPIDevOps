using Data_Access.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Data.DBContext
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Claims> Reimbursement { get; set; }
        public DbSet<PendingRequests> Pending { get; set; }
        public DbSet<ApprovedRequests> Approved { get; set; }
        public DbSet<DeclineRequests> Decline { get; set; }
    }
}
