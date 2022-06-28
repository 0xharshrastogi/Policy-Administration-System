import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './pages/signup/signup.component';
import { CustomerComponent } from './customer/customer.component';
import { PolicyComponent } from './policy/policy.component';


const routes: Routes = [{ path: 'signup', component: SignupComponent }, { path: 'customer', component: CustomerComponent }, { path: 'policy/Create', component: PolicyComponent }];
// const routes: Routes = [];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
