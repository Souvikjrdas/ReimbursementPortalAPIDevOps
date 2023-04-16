using Data_Access.Data.DBContext;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ClaimRepository : Repository<Claims>,IClaimRepository
    {
        private readonly ApplicationDbContext db;

        public ClaimRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public IEnumerable<Claims>? GetClaimsByEmail(string email)
        {
            var ob = db.Reimbursement.ToList();
            if(ob != null)
            {
                return ob.Where(item => item.EmployeeMail == email).ToArray();
            }
            else
            {
                return null;
            }
        }

        public void Update(Claims ob)
        {
            db.Reimbursement.Update(ob);
        }
    }
}
