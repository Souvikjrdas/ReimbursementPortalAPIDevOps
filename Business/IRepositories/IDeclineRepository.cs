using Data_Access.Entities;

namespace Business.Repositories
{
    public interface IDeclineRepository : IRepository<DeclineRequests>
    {
        void Update(DeclineRequests ob);
    }
}