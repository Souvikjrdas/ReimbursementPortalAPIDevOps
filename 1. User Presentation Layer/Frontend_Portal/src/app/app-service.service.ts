import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable,pipe,catchError,filter,map,tap, Observer , throwError, from, of} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  constructor(private http:HttpClient) { }

  capiUrl= "http://localhost:56092/api/AccountAPI/";
  clapiURL = "http://localhost:56092/api/Claim/";
  alapiURL = "http://localhost:56092/api/Admin/";


  //Register User
  SignUp(data:any):Observable<any>{
    return this.http.post<Observable<any>>(`${this.capiUrl}`+"SignUp",data)
  }

  //Sign In
  SignIn(data:any):Observable<any>{
    return this.http.post(`${this.capiUrl}`+"LogIn",data)
  }

  //Log out

  SignOut():Observable<any>{
   return this.http.get(`${this.capiUrl}`+"LogOut");
  }
  //Get Signed In User

  UserDetails():Observable<any>{
    return this.http.get(`${this.capiUrl}`+"CurrentUser");
  }

  //Get Claim byId

  GetClaimById(id:any):Observable<any>{
    return this.http.get(`${this.clapiURL}`+"getClaim/"+id);
  }

  //Get Claims By email

  ClaimsByEmail(email:string):Observable<any>{
    return this.http.get(`${this.clapiURL}`+"GetClaimsByEmail/"+email);
  }

  //Post claim

 CreateClaim(claim:any) : Observable<any>{
   return this.http.post(`${this.clapiURL}`+"create",claim);
 }

 //Update claim

 UpdateClaim(id:any,data:any):Observable<any>{
   return this.http.put(`${this.clapiURL}`+"edit/"+id,data);
 }

 //Delete Claim

 Deleteclaim(id:any):Observable<any>{
   return this.http.delete(`${this.clapiURL}`+"delete/"+id);
 }

 //Get Pending claims

 PendingClaims():Observable<any>{
   return this.http.get(`${this.alapiURL}`+"getPendingClaims");
 }

 //Get Approved Claims

 ApprovedClaims():Observable<any>{
   return this.http.get(`${this.alapiURL}`+"getApprovedClaims");
 }

 //Get  Declined Claims

 DeclinedCLaims():Observable<any>{
   return this.http.get(`${this.alapiURL}`+"GetDeclinedClaims");
 }

 //Create Approved Claim

 CreateApproved(data:any){
   return this.http.post(`${this.alapiURL}`+"AddApprovedClaim",data);
 }

 //Create Declined Claim

 CreateDeclined(data:any){
   return this.http.post(`${this.alapiURL}`+"AddDeclinedClaim",data);
 }

}
