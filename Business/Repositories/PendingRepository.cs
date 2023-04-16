using Data_Access.Data.DBContext;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class PendingRepository : Repository<PendingRequests>,IPendingRepository
    {
        private readonly ApplicationDbContext db;

        public PendingRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public void Update(PendingRequests ob)
        {
            db.Pending.Update(ob);
        }
    }
}
