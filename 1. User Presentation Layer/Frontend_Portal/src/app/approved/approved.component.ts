import { Component, OnInit,Input } from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";
import { NgForm } from '@angular/forms';

interface DTO{
  ReimbursementType:string,
  InternalNotes:string,
  ApprovedBy:string,
  ApprovedValue:string,
  Currency:string,
  Date:Date,
  EmployeeMail:string,
  RequestedValue:string
}
@Component({
  selector: 'app-approved',
  templateUrl: './approved.component.html',
  styleUrls: ['./approved.component.css']
})
export class ApprovedComponent implements OnInit {

  Claims:any
  ApprovedDTO:DTO = {
    ReimbursementType:"",
    InternalNotes:"",
    ApprovedBy:"",
    ApprovedValue:"",
    Currency:"",
    Date: new Date(),
    EmployeeMail: "",
    RequestedValue: ""
  } 
  constructor(private service:AppServiceService , private router:Router) { }

  @Input() Id:any

  ngOnInit(): void {
  }

  getForm(ApproveClaim:NgForm){
    console.log(this.Id);
    this.service.GetClaimById(this.Id).subscribe((res:any)=>{
      this.Claims = res

      //set changes in Claim
      this.Claims.approvedValue  = ApproveClaim.value.ApprovedValue;
      this.Claims.requestPhase = "Processed";
      this.Claims.isApproved = true;

      this.service.UpdateClaim(this.Id,this.Claims).subscribe((res:any)=>{

        if(res.info == "Successfully Updated!"){

          //create Approved Claim

          //from form
          this.ApprovedDTO.ApprovedBy = ApproveClaim.value.ApprovedBy;
          this.ApprovedDTO.ApprovedValue = ApproveClaim.value.ApprovedValue;
          this.ApprovedDTO.InternalNotes = ApproveClaim.value.InternalNotes;

          //from get api
          this.ApprovedDTO.Currency = this.Claims.currency;
          this.ApprovedDTO.Date = this.Claims.date;
          this.ApprovedDTO.ReimbursementType = this.Claims.reimbursementType;
          this.ApprovedDTO.RequestedValue = this.Claims.requestedValue;
          this.ApprovedDTO.EmployeeMail = this.Claims.employeeMail;

          this.service.CreateApproved(this.ApprovedDTO).subscribe((res:any)=>{
            alert(res.info);
            if(res.info == "Claim Approved!"){
              ApproveClaim.resetForm();
            }
            
          })
        }
        else{
          alert("Error occurred while approving the claim!");
        }
      })
    })
  }



  

}
