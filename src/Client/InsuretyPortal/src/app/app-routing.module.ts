import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PolicyComponent } from './policy/policy.component';

const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  { path: 'customer', component: CustomerComponent/*, canActivate: [AuthGuard] */},
  { path: 'policy', component: PolicyComponent },
  { path: 'customer-view/:id', component: CustomerViewComponent },
  { path: 'login', component: LoginFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
