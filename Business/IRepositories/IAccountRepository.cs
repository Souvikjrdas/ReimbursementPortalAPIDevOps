using Business.DTO;
using Data_Access.Entities;
using Microsoft.AspNetCore.Identity;

namespace Business.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateMyAsync(AccountDTO ob);

        Task<SignInResult> MySignInAsync(LogInDTO ob);

        Task MySignInOutAsync();

        IEnumerable<ApplicationIdentityUser> GetAll();

        Task<IdentityResult> DeleteIdentity(string userId);
    }
}