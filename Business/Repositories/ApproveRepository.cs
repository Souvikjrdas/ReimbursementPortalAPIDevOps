using Data_Access.Data.DBContext;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ApproveRepository : Repository<ApprovedRequests> , IApproveRepository
    {
        private readonly ApplicationDbContext db;

        public ApproveRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(ApprovedRequests ob)
        {
            db.Approved.Update(ob);
        }

    }
}
