using Business.Repositories;

namespace Business.Transaction._1.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IClaimRepository Claim { get;}
        public IApproveRepository Appr { get;}
        public IDeclineRepository Dec { get;}
        public IPendingRepository Pend { get;}
        public IAccountRepository Arepo { get; }
        void Save();

    }
}