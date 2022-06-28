import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputTextComponent } from './input-text/input-text.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CustomerComponent } from './customer/customer.component';
import { PolicyComponent } from './policy/policy.component';
<<<<<<< HEAD
import { NavbarComponent } from './navbar/navbar.component';
import { ConsumersDisplayComponent } from './consumers-display/consumers-display.component';
import { PolicyDisplayComponent } from './policy-display/policy-display.component';

@NgModule({
  declarations: [AppComponent, InputTextComponent, SignupComponent, CustomerComponent, PolicyComponent, NavbarComponent, ConsumersDisplayComponent, PolicyDisplayComponent],
=======
import { ListPolicyComponent } from './list-policy/list-policy.component';

@NgModule({
  declarations: [AppComponent, InputTextComponent, SignupComponent, CustomerComponent, PolicyComponent, ListPolicyComponent],
>>>>>>> b446bb55bf634a6ec56fd35baa66288662018865
  imports: [CommonModule, BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
