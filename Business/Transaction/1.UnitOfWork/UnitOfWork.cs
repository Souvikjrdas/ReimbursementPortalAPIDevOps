using Business.Repositories;
using Data_Access.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Transaction._1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public IClaimRepository Claim { get; private set; }
        public IApproveRepository Appr { get; private set; }
        public IDeclineRepository Dec { get; private set; }
        public IPendingRepository Pend { get; private set; }
        public IAccountRepository Arepo { get; private set; }

        public UnitOfWork(IClaimRepository claim , IApproveRepository appr, IDeclineRepository dec , IPendingRepository pend,ApplicationDbContext _db , IAccountRepository arepo)
        {
            db = _db;
            Arepo = arepo;
            Claim = claim;
            Appr = appr;
            Dec = dec;
            Pend = pend;
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
