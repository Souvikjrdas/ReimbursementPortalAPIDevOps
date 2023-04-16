import { Component, OnInit } from '@angular/core';
import {AppServiceService} from '../app-service.service';
import {Router} from "@angular/router";
@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.css']
})
export class EmployeeDashboardComponent implements OnInit {

  email:string = ""
  Claims:any = []
  ActivateAddComponent:boolean = false
  ModalTitle: string = ""
  constructor(private service:AppServiceService,private router:Router) { }

  ngOnInit(): void {
     if(localStorage.getItem("Email")){
       this.email = <string>localStorage.getItem("Email")
     }
     this.refreshList();
  }

  refreshList(){
    this.service.ClaimsByEmail(this.email).subscribe((res:any)=>{
      this.Claims = res;
     // console.log(this.Claims);
    //  for(let item of this.Claims){
    //    console.log(item.id);
    //   console.log(item.date);
    //   console.log(item.reimbursementType);
    //   console.log(item.requestedValue);
    //   console.log(item.approvedValue);
    //   console.log(item.currency);
    //   console.log(item.requestPhase);
    //   console.log(item.reciept);

    //  }
    }
    )
  }

  addClick(){
    this.ModalTitle = "Add Reimbursement"
    this.ActivateAddComponent = true
  }

  Close(){
    this.ActivateAddComponent = false
    this.refreshList();
  }

  DeleteClaim(id:any){
    this.service.Deleteclaim(id).subscribe((res:any)=>{
      alert(res.info);
      this.refreshList();
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

  // GetUser(){
  //   this.service.UserDetails().subscribe(res=>{
  //     console.log(res)
  //   })
  // }

  
}
