import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CustomerComponent } from './pages/customer/customer.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PolicyComponent } from './policy/policy.component';
import { ListPolicyComponent } from './list-policy/list-policy.component';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';
const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  { path: 'customer', component: CustomerComponent/*,canActivate: [AuthGuard]*/ },
  { path: 'policy', component: PolicyComponent },
  {path:'listpolicy',component:ListPolicyComponent},
  {path:'customer-view',component:CustomerViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
