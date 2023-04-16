using Data_Access.Entities;

namespace Business.Repositories
{
    public interface IApproveRepository : IRepository<ApprovedRequests>
    {
        void Update(ApprovedRequests ob);
    }
}