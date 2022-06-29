import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputTextComponent } from './input-text/input-text.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { PolicyComponent } from './policy/policy.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ConsumersDisplayComponent } from './consumers-display/consumers-display.component';
import { PolicyDisplayComponent } from './policy-display/policy-display.component';
import { ListPolicyComponent } from './list-policy/list-policy.component';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';
import { CustomerInputComponent } from './pages/customer-input/customer-input.component';
import { LoginFormComponent } from './login-form/login-form.component';

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
  ],
  imports: [CommonModule, BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
