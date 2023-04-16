import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {AppServiceService} from '../app-service.service';
import {Router} from '@angular/router';


interface LogInDTO{
  Email:string,
  Password : string
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  ob : LogInDTO = {
    Email:"",
    Password:""
  }

  alert:boolean = false
  arr:Array<any> = []
  constructor(private service:AppServiceService , private router:Router) { }

  ngOnInit(): void {
  }

  getForm(LogIn:NgForm){
    this.ob.Email = LogIn.value.Email,
    this.ob.Password = LogIn.value.Password

    this.service.SignIn(this.ob).subscribe(res=>{
      console.log(res)
      if(res.succeeded){
        localStorage.setItem("Email",LogIn.value.Email)
        if(this.ob.Email == "admin@claims.com"){
          this.router.navigate(["/admin/Dashboard"])  
        }
        else{
          this.router.navigate(["/emp/Dashboard"])
        }
      }
      else{
        this.arr = new Array()
        this.arr.push("Invalid credentials!")
        this.alert = true
        LogIn.resetForm()
      }
      
    })

  }

  buttonClose(){
    this.alert = false
    this.arr = new Array()
  }

}
