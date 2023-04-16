using Data_Access.Data.DBContext;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class DeclineRepository : Repository<DeclineRequests> , IDeclineRepository
    {
        private readonly ApplicationDbContext db;

        public DeclineRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(DeclineRequests ob)
        {
            db.Update<DeclineRequests>(ob);
        }
    }
}
