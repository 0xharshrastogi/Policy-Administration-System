import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { LoginFormComponent } from './login-form/login-form.component';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PolicyComponent } from './policy/policy.component';
import { CustomerInputComponent } from './pages/customer-input/customer-input.component';
import { BusinessInputComponent } from './pages/business-input/business-input.component';

const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  {
    path: 'customer',
    component: CustomerComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'policy',
    component: PolicyComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'customer-view/:id',
    component: CustomerViewComponent,
    canActivate: [AuthGuard],
  },
  { path: 'login', component: LoginFormComponent },
  { path: 'customerinput', component: CustomerInputComponent },
  { path: 'customer-view/:id/Addbusiness', component: BusinessInputComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
