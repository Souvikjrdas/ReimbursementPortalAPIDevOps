using Business.DTO;
using Business.Transaction._1.UnitOfWork;
using Data_Access.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly UserManager<ApplicationIdentityUser> um;
        private readonly SignInManager<ApplicationIdentityUser> sm;

        public AccountAPIController(IUnitOfWork uow , UserManager<ApplicationIdentityUser> _um , SignInManager<ApplicationIdentityUser> _sm)
        {
            this.uow = uow;
            um = _um;
            sm = _sm;
        }

        [HttpPost("SignUp")]

        public async Task<IActionResult> SignUp(AccountDTO ob)
        {
            if (ob == null)
            {
                return BadRequest();
            }
            var result = await uow.Arepo.CreateMyAsync(ob);
            return Ok(result);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInDTO ob)
        {
            if(ob == null)
            {
                return BadRequest();
                
            }
            var result = await uow.Arepo.MySignInAsync(ob);
            return Ok(result);
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await uow.Arepo.MySignInOutAsync();
            return Ok(true);
        }


        //To Get  Current logged In User
        [HttpGet("CurrentUser")]

        public ApplicationIdentityUser CurrentUser()
        {
            var res1 = um.GetUserId(HttpContext.User);
            var res2 = um.FindByIdAsync(res1).Result;
            return res2;
        }
    }
}
