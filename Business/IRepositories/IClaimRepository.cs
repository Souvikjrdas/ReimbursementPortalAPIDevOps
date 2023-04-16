using Data_Access.Entities;

namespace Business.Repositories
{
    public interface IClaimRepository : IRepository<Claims>
    {
        IEnumerable<Claims>? GetClaimsByEmail(string email);
        void Update(Claims ob);
    }
}