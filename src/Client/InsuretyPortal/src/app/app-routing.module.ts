import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CustomerComponent } from './customer/customer.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PolicyComponent } from './policy/policy.component';

<<<<<<< HEAD

const routes: Routes = [{ path: 'signup', component: SignupComponent }, { path: 'customer', component: CustomerComponent }, { path: 'policy/Create', component: PolicyComponent }];
// const routes: Routes = [];
=======
const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  { path: 'customer', component: CustomerComponent, canActivate: [AuthGuard] },
  { path: 'policy', component: PolicyComponent },
];

>>>>>>> b446bb55bf634a6ec56fd35baa66288662018865
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
