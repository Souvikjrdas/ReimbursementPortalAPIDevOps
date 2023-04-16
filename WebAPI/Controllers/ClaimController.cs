using AutoMapper;
using Business.Repositories;
using Business.Transaction._1.UnitOfWork;
using Data_Access.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Helpers.DTO;
using WebAPI.Helpers.Mappers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper map;
        private readonly Message mssg;

        public ClaimController(IUnitOfWork uow , IMapper _map)
        {
            this.uow = uow;
            map = _map;
            mssg = new Message();
        }

        //To Get all claims
        [HttpGet("getClaims")]
        public async Task<IActionResult> GetallClaims()
        {
            var res = await uow.Claim.GetAllAsync();
            if(res != null)
            {
                return Ok(res);
            }
            return NotFound(null);
            
        }

        [HttpGet("getClaim/{id}")]

        public async Task<IActionResult> GetClaim(int id)
        {
            var claim = await uow.Claim.GetAsync(id);
            if(claim != null)
            {
                return Ok(claim);
            }
            else
            {
                return NotFound(null);
            }
        }

        [HttpGet("GetClaimsByEmail/{email}")]
        public IEnumerable<Claims>? GetAllClaimsByemail(string email)
        {
            var claims = uow.Claim.GetClaimsByEmail(email);
            return claims;
        }

        [HttpPost("create")]

        public async Task<IActionResult> CreateClaim(ClaimsDTO ob)
        {
            ob.RequestPhase = "ToBeProcessed";
            ob.IsApproved = false;
            var ob1  = map.Map<Claims>(ob);
            var res = await uow.Claim.GetAllAsync();
            if(res != null)
            {
                var res1 = res.Where(x => x.EmployeeMail == ob.EmployeeMail && x.ReimbursementType == ob.ReimbursementType).FirstOrDefault();
                if(res1 == null)
                {
                    uow.Claim.Add(ob1);
                    uow.Save();
                    mssg.Info = "Claim Added!";
                    return Ok(mssg);
                }
                else
                {
                    mssg.Info = "Claim already exists!";
                    return Ok(mssg);
                }
            }
            else
            {
                uow.Claim.Add(ob1);
                uow.Save();
                mssg.Info = "Claim Added!";
                return Ok(mssg);
            }

        }

        [HttpPut("edit/{id}")]

        public async Task<IActionResult> UpdateClaim(int id, ClaimsEditDTO ob)
        {
            var ob1 =  await uow.Claim.GetAsync(id);
            
            if(ob1 != null)
            {
                //var res1 = await uow.Claim.GetAllAsync();             
                //var res2 = res1.Where(x => x.EmployeeMail == ob.EmployeeMail && x.ReimbursementType == ob.ReimbursementType).FirstOrDefault();
                //if(res2 == null)
                //{
                if (ob1.Id == ob.Id && ob1.EmployeeMail == ob.EmployeeMail && ob1.ReimbursementType == ob.ReimbursementType)
                {
                    map.Map(ob, ob1);
                    ob1.Id = id;
                    uow.Claim.Update(ob1);
                    uow.Save();
                    mssg.Info = "Successfully Updated!";
                    return Ok(mssg);
                }
                else
                {
                    mssg.Info = "Cannot Update!";
                    return Ok(mssg);
                }
                //}
                //else
                //{
                //    mssg.Info = "Reimbursement already exists!";
                //    return Ok(mssg);
                //}               

            }
            else
            {
                mssg.Info = "Cannot Update! Record not found!";
                return Ok(mssg);
            }

        }


        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteClaim (int id)
        {
            var ob1 = await uow.Claim.GetAsync(id);
            if(ob1 != null)
            {
                uow.Claim.Remove(ob1);
                uow.Save();
                mssg.Info = "Claim Deleted!";
                return Ok(mssg);

            }
            else
            {
                mssg.Info = "Claim can not be deleted!";
                return Ok(mssg);
            }
            
        }



    }
}
