import { Component, OnInit } from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";

interface DTO{
  ReimbursementType:string,
  InternalNotes:string,
  Currency:string,
  Date:Date,
  EmployeeMail:string,
  RequestedValue:string
}
@Component({
  selector: 'app-pending',
  templateUrl: './pending.component.html',
  styleUrls: ['./pending.component.css']
})
export class PendingComponent implements OnInit {

  Claims:any = []
  ActivateAddComponent:boolean = false
  ModalTitle: string = ""
  empId:any

  Claim:any
  DeclinedDTO:DTO = {
    ReimbursementType:"",
    InternalNotes:"",
    Currency:"",
    Date: new Date(),
    EmployeeMail: "",
    RequestedValue: ""
  } 
  constructor(private service:AppServiceService , private router:Router) { }

  ngOnInit(): void {
    this.refreshPending();
  }

  refreshPending(){
    this.service.PendingClaims().subscribe((res:any)=>{
      this.Claims = res;
    })
  }

  addClick(id:any)
  {
      this.ActivateAddComponent = true;
      this.ModalTitle = "Approve Reimbursement"
      this.empId = id;
  }

  Close(){
    this.ActivateAddComponent = false;
    this.empId = 0;
    this.refreshPending();
  }

  Decline(DId:any){
    this.service.GetClaimById(DId).subscribe((res:any)=>{
      this.Claim = res;

      this.Claim.requestPhase = "Processed";
      this.Claim.isApproved = false;

      this.service.UpdateClaim(DId,this.Claim).subscribe((res:any)=>{

        if(res.info == "Successfully Updated!"){


          this.DeclinedDTO.Date = this.Claim.date;
          this.DeclinedDTO.Currency = this.Claim.currency;
          this.DeclinedDTO.EmployeeMail = this.Claim.employeeMail;
          this.DeclinedDTO.ReimbursementType = this.Claim.reimbursementType;
          this.DeclinedDTO.RequestedValue  = this.Claim.requestedValue;

          this.service.CreateDeclined(this.DeclinedDTO).subscribe((res:any)=>{
            alert(res.info);
          })
          this.refreshPending();
        }

        else{
          alert("An error occurred!");
        }
      })

    })
  }

  LogOut(){
    this.service.SignOut().subscribe(res=>{
      if(res){
        localStorage.removeItem("Email")
        this.router.navigate(["/"])
      }
    })
  }

}
