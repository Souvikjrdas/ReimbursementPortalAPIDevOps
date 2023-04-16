using Business.DTO;
using Data_Access.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationIdentityUser> um;
        private readonly SignInManager<ApplicationIdentityUser> sm;
        private readonly RoleManager<IdentityRole> rm;

        public AccountRepository(UserManager<ApplicationIdentityUser> _um, SignInManager<ApplicationIdentityUser> _sm, RoleManager<IdentityRole> _rm )
        {
            um = _um;
            sm = _sm;
            rm = _rm;
        }

        public async Task<IdentityResult> CreateMyAsync(AccountDTO ob)
        {
            var user = new ApplicationIdentityUser()
            {
                FullName = ob.FullName,
                PAN = ob.PAN,
                UserName = ob.Email,
                Bank = ob.Bank,
                AccountNo = Convert.ToInt64(ob.AccountNo),
                Email = ob.Email,
            };

            var result = await um.CreateAsync(user, ob.Password);
            if (user.Email == "admin@claims.com")
            {
                IdentityRole ob1 = new IdentityRole();
                ob1.Name = "Admin";
                await rm.CreateAsync(ob1);
                await um.AddToRoleAsync(user, ob1.Name);
            }

            return result;
        }

        public Task<IdentityResult> DeleteIdentity(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationIdentityUser> GetAll()
        {
            return um.Users;
        }

        public async Task<SignInResult> MySignInAsync(LogInDTO ob)
        {
            var result = await sm.PasswordSignInAsync(ob.Email, ob.Password, false, false);
            return result;
        }

        public async Task MySignInOutAsync()
        {
            await sm.SignOutAsync();

        }

        
    }
}
