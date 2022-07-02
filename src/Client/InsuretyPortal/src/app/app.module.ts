import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConsumerBusinessPropertyComponent } from './consumer-business-property/consumer-business-property.component';
import { ConsumersDisplayComponent } from './consumers-display/consumers-display.component';
import { CreatePolicyComponent } from './create-policy/create-policy.component';
import { CustomerBusinessComponent } from './customer-business/customer-business.component';
import { InputTextComponent } from './input-text/input-text.component';
import { ListPolicyComponent } from './list-policy/list-policy.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BusinessInputComponent } from './pages/business-input/business-input.component';
import { CustomerInputComponent } from './pages/customer-input/customer-input.component';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { SignupComponent } from './pages/signup/signup.component';
import { PolicyDisplayComponent } from './policy-display/policy-display.component';
import { PolicyComponent } from './policy/policy.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { PropertyInputComponent } from './pages/property-input/property-input.component';
import { HomeComponent } from './home/home.component';
import { IssuePolicyFormComponent } from './issue-policy-form/issue-policy-form.component';

@NgModule({
  declarations: [
    AppComponent,
    InputTextComponent,
    SignupComponent,
    CustomerComponent,
    PolicyComponent,
    ListPolicyComponent,
    NavbarComponent,
    PolicyDisplayComponent,
    ConsumersDisplayComponent,
    CustomerViewComponent,
    CustomerInputComponent,
    LoginFormComponent,
    CustomerBusinessComponent,
    ConsumerBusinessPropertyComponent,
    BusinessInputComponent,
    SpinnerComponent,
    CreatePolicyComponent,
    PropertyInputComponent,
    HomeComponent,
    IssuePolicyFormComponent,
  ],
  imports: [CommonModule, BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
