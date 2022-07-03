import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: [
    './signup.component.css',
    '../../login-form/login-form.component.css',
  ],
  providers: [AuthenticationService],
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  isSigningUp: boolean = false;

  public errors: string[] = [];

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {
    this.signupForm = new FormGroup({
      name: new FormControl('', Validators.required),
      userName: new FormControl('', [
        Validators.required,
        Validators.minLength(5),
      ]),
      password: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  ngOnInit(): void {}

  async onSubmit() {
    try {
      if (this.signupForm.valid) {
        this.isSigningUp = true;
        await this.authService.signup(this.signupForm.value);
        // navigating to customer dashboard;
        this.router.navigate(['/customer']);
      }
    } catch (error) {
      this.errors.push((<Error>error).message);
    } finally {
      this.isSigningUp = false;
    }
  }
}
