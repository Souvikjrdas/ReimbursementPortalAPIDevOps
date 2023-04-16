import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddClaimComponent } from './add-claim/add-claim.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { ApprovedClaimsComponent } from './approved-claims/approved-claims.component';
import { ApprovedComponent } from './approved/approved.component';
import { DeclineComponent } from './decline/decline.component';
import { DelClaimComponent } from './del-claim/del-claim.component';
import { EditClaimComponent } from './edit-claim/edit-claim.component';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { LoginComponent } from './login/login.component';
import { PendingComponent } from './pending/pending.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: "",
    component: LoginComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "emp/Dashboard",
    component: EmployeeDashboardComponent
  },
  {
    path: "admin/Dashboard",
    component: AdminDashboardComponent
  },
  {
    path: "admin/pending",
    component: PendingComponent
  },
  {
    path:"admin/approved",
    component: ApprovedComponent
  },
  {
    path:"admin/decline",
    component: DeclineComponent
  },
  {
    path:"admin/approvedClaims",
    component: ApprovedClaimsComponent
  },
  {
    path: "emp/AddClaim",
    component: AddClaimComponent
  },
  {
    path: "emp/EditClaim/:id",
    component: EditClaimComponent
  },
  {
    path: "emp/DeleteClaim/:id",
    component: DelClaimComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
