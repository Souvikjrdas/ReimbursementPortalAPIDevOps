import { registerLocaleData } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {AppServiceService} from '../app-service.service';
import {Router} from '@angular/router';

interface Type{
  Email:string,
  Password:string,
  FullName:string,
  PAN:string,
  Bank:string,
  AccountNo:string
}
interface LogInDTO{
  Email:string,
  Password : string
}
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  AccountDTO:Type = {
    Email:"",
    Password:"",
    FullName:"",
    PAN:"",
    Bank:"",
    AccountNo:""
  }

  LogInDTO:LogInDTO = {
    Email: "",
    Password: ""
  }

  alert:boolean = false
  signIn:boolean = false
  arr:Array<any> = []

  constructor(private service:AppServiceService, private router:Router) { }

  ngOnInit(): void {

  }

  getForm(Register:NgForm){
    
    if(Register.value.Password != Register.value.confirmpassword){
      this.arr = new Array
      this.arr.push("Passwords do not match!");
      this.alert = true
    }

    else{
      this.AccountDTO.Email = Register.value.Email
      this.AccountDTO.AccountNo = Register.value.AccountNo
      this.AccountDTO.Bank = Register.value.Bank
      this.AccountDTO.PAN = Register.value.PAN
      this.AccountDTO.Password = Register.value.Password
      this.AccountDTO.FullName = Register.value.FullName
      console.log(this.AccountDTO)

    this.service.SignUp(this.AccountDTO).subscribe(res=>{

      if(res.succeeded){

        this.LogInDTO.Email  = Register.value.Email
        this.LogInDTO.Password = Register.value.Password

        this.service.SignIn(this.LogInDTO).subscribe(res1=>{
          if(res1.succeeded){
            localStorage.setItem("Email",Register.value.Email);
            if(this.AccountDTO.Email == "admin@claims.com"){
              this.router.navigate(['/admin/Dashboard'])
            }
            else{
              this.router.navigate(['/emp/Dashboard'])
            }
          }
          else{
           this.arr = new Array
            this.arr.push("Could not sign you in! Try again")
            this.alert = true
            Register.resetForm()
          }
        })
      }

      else{
        this.arr = new Array
        for(let item of res.errors){
          this.arr.push(item.description);
        }
        this.alert = true
        Register.resetForm()
      }

    })

    }
  } 

  buttonClose(){
    this.alert = false;
    this.arr = new Array;
  }

  // LogOut(){
  //   this.service.SignOut().subscribe(res=>{
  //     if(res){
  //       localStorage.removeItem("Email")
  //       this.router.navigate([""])
  //     }
  //   })
  // }

}
