import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextComponent } from '../input-text/input-text.component';

import { SignupComponent } from '../pages/signup/signup.component';
import { SignupRoutingModule } from './signup-routing.module';

@NgModule({
  declarations: [SignupComponent, InputTextComponent],
  imports: [CommonModule, ReactiveFormsModule, SignupRoutingModule],
})
export class SignupModule {}
