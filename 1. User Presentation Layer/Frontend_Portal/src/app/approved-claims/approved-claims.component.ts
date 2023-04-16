import { Component, OnInit } from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";
@Component({
  selector: 'app-approved-claims',
  templateUrl: './approved-claims.component.html',
  styleUrls: ['./approved-claims.component.css']
})
export class ApprovedClaimsComponent implements OnInit {


  Claims:any = []
  constructor(private service:AppServiceService , private router:Router) { }

  ngOnInit(): void {

    this.service.ApprovedClaims().subscribe((res:any)=>{
      this.Claims = res;
      console.log(this.Claims);
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
