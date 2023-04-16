using Data_Access.Entities;

namespace Business.Repositories
{
    public interface IPendingRepository : IRepository<PendingRequests>
    {
        void Update(PendingRequests ob);
    }
}