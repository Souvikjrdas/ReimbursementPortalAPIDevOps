import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {AppServiceService} from '../app-service.service';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

interface DTO{
  id:any
  employeeMail:string
  date:any
  reimbursementType: string
  requestedValue: string
  approvedValue: string
  currency: string
  requestPhase: string
  isApproved: boolean
  reciept: string
}
@Component({
  selector: 'app-edit-claim',
  templateUrl: './edit-claim.component.html',
  styleUrls: ['./edit-claim.component.css']
})
export class EditClaimComponent implements OnInit {

  id : any

  ClaimsEditDTO : DTO = {
  id : 0,
  employeeMail:"",
  date: new Date(),
  reimbursementType: "",
  requestedValue: "",
  approvedValue: "",
  currency: "",
  requestPhase: "",
  isApproved: false,
  reciept: "",
  }
  constructor(private service:AppServiceService, private router:Router,private _activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    this.service.GetClaimById(this.id).pipe(map(item => )).subscribe((res:any)=>{
      this.ClaimsEditDTO = res
      console.log(this.ClaimsEditDTO)
    })

  }

  Edit(editClaim:NgForm){
    this.ClaimsEditDTO.date = editClaim.value.Date;
    // this.ClaimsEditDTO.reimbursementType = editClaim.value.ReimbursementType;
    this.ClaimsEditDTO.requestedValue = editClaim.value.RequestedValue;
    this.ClaimsEditDTO.currency = editClaim.value.Currency;
    console.log(this.ClaimsEditDTO)

    this.service.UpdateClaim(this.id,this.ClaimsEditDTO).subscribe((res:any)=>{
      if(res.info == "Successfully Updated!"){
        editClaim.resetForm();
        alert("Successfully Updated!")
        this.router.navigate(["/emp/Dashboard"])
      }
      else{
        alert(res.info);
      }
    })

  }

}
