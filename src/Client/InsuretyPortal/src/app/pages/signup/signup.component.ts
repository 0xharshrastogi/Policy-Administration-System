import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  signupForm = new FormGroup({
    name: new FormControl('', Validators.required),
    userName: new FormControl([
      '',
      Validators.required,
      Validators.minLength(5),
    ]),
    password: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
  });

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  async signup() {
    await this.authService.login({
      name: this.signupForm.get('name')!.value,
      email: this.signupForm.get('email')!.value,
      userName: this.signupForm.get('userName')!.value,
      password: this.signupForm.get('password')!.value,
    });
  }
}
