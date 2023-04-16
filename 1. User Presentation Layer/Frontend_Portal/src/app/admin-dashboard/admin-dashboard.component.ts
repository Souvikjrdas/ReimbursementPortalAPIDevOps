import { Component, OnInit } from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  constructor(private service:AppServiceService , private router:Router) { }

  ngOnInit(): void {
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
