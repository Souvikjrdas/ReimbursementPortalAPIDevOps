using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Business.Repositories;
using Business.Transaction._1.UnitOfWork;
using Data_Access.Entities;
using WebAPI.Helpers;
using WebAPI.Helpers.DTO;
using WebAPI.Helpers.Mappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper map;
        private readonly Message mssg;

        public AdminController(IUnitOfWork uow, IMapper _map)
        {
            this.uow = uow;
            this.map = _map;
            mssg = new Message();
        }

        //To Get All Pending Claims - ToBeProcessed

        [HttpGet("getPendingClaims")]

        public async Task<IEnumerable<Claims>?> GetClaims()
        {
            var res = await uow.Claim.GetAllAsync();
            if(res != null)
            {
                var ob = res.Where(item => item.RequestPhase == "ToBeProcessed");
                if(ob != null)
                {
                    return ob.ToArray();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        //Update Claim

        [HttpPut("edit/{id}")]

        public async Task<IActionResult> UpdateClaim(int id, ClaimsEditDTO ob)
        {
            var ob1 = await uow.Claim.GetAsync(id);

            if (ob1 != null)
            {
                //var res1 = await uow.Claim.GetAllAsync();
                //var res2 = res1.Where(x => x.EmployeeMail == ob.EmployeeMail && x.ReimbursementType == ob.ReimbursementType).FirstOrDefault();
                //if (res2 == null)
                //{
                if(ob1.Id == ob.Id && ob1.EmployeeMail == ob.EmployeeMail && ob1.ReimbursementType == ob.ReimbursementType)
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



        //Get Approved Claims

        [HttpGet("getApprovedClaims")]

        public async Task<IEnumerable<ApprovedRequests>?> GetAllApproved()
        {
            var res = await uow.Appr.GetAllAsync();
            if(res != null)
            {
                return res.ToArray();
            }
            else
            {
                return null;
            }

        }

        //Create Approved Claim

        [HttpPost("AddApprovedClaim")]

        public IActionResult AddApprove(ApprovedDTO ob)
        {
            if(ob != null)
            {
                var ob1 = map.Map<ApprovedRequests>(ob);
                uow.Appr.Add(ob1);
                uow.Save();
                mssg.Info = "Claim Approved!";
                return Ok(mssg);
            }
            else
            {
                mssg.Info = "Claim was not Approved!";
                return Ok(mssg);
            }
        }


        //Get Declined Claims

        [HttpGet("GetDeclinedClaims")]

        public async Task<IEnumerable<DeclineRequests>?> GetDeclined()
        {
            var res = await uow.Dec.GetAllAsync();
            if(res != null)
            {
                return res.ToArray();
            }
            else 
            { 
                return null; 
            }
        }

        //Create Declined Claim

        [HttpPost("AddDeclinedClaim")]

        public IActionResult AddDecline(DeclineDTO ob)
        {
            if(ob != null)
            {
                var ob1 = map.Map<DeclineRequests>(ob);
                uow.Dec.Add(ob1);
                uow.Save();
                mssg.Info = "Claim Declined"!;
                return Ok(mssg);    
            }
            else
            {
                mssg.Info = "Claim not declined!";
                return Ok(mssg);
            }
        }
    }
}
