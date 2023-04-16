import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { HeaderComponent } from './header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HttpClientModule} from '@angular/common/http';
import { AddClaimComponent } from './add-claim/add-claim.component';
import { EditClaimComponent } from './edit-claim/edit-claim.component';
import { DelClaimComponent } from './del-claim/del-claim.component';
import { PendingComponent } from './pending/pending.component';
import { ApprovedComponent } from './approved/approved.component';
import { DeclineComponent } from './decline/decline.component';
import { ApprovedClaimsComponent } from './approved-claims/approved-claims.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    EmployeeDashboardComponent,
    AdminDashboardComponent,
    HeaderComponent,
    AddClaimComponent,
    EditClaimComponent,
    DelClaimComponent,
    PendingComponent,
    ApprovedComponent,
    DeclineComponent,
    ApprovedClaimsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
