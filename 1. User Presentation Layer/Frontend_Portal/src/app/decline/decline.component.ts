import { Component, OnInit } from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";
@Component({
  selector: 'app-decline',
  templateUrl: './decline.component.html',
  styleUrls: ['./decline.component.css']
})
export class DeclineComponent implements OnInit {

  Claims:any = []

  constructor(private service:AppServiceService , private router:Router) { }

  ngOnInit(): void {

    this.service.DeclinedCLaims().subscribe((res:any)=>{
      this.Claims = res;
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
