import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {AppServiceService} from '../app-service.service';

interface dtype{
  Date: Date,
  ReimbursementType:string,
  RequestedValue: string,
  Currency:string
  EmployeeMail:string
}
@Component({
  selector: 'app-add-claim',
  templateUrl: './add-claim.component.html',
  styleUrls: ['./add-claim.component.css']
})
export class AddClaimComponent implements OnInit {

  email:string = ""

  ClaimsDTO : dtype = {
    Date: new Date(),
    ReimbursementType: "",
    RequestedValue: "",
    Currency: "",
    EmployeeMail: ""
  }
  constructor(private service:AppServiceService) { }

  ngOnInit(): void {
    if(localStorage.getItem("Email")){
      this.email = <string>localStorage.getItem("Email")
    }
    console.log(this.email)
  }

  getForm(AddClaim:NgForm){
    
    this.ClaimsDTO.Date = AddClaim.value.Date,
    this.ClaimsDTO.ReimbursementType = AddClaim.value.ReimbursementType,
    this.ClaimsDTO.RequestedValue = AddClaim.value.RequestedValue,
    this.ClaimsDTO.Currency = AddClaim.value.Currency,
    this.ClaimsDTO.EmployeeMail = this.email

    console.log(this.email)
    console.log(this.ClaimsDTO.EmployeeMail)
    this.service.CreateClaim(this.ClaimsDTO).subscribe((res:any)=>{
      if(res.info == "Claim Added!"){
        alert("Claim Added!")
        AddClaim.resetForm();
      }
      else{
        alert("Claim already exists!")
      }
      console.log(res.info);
    })
  }

}
