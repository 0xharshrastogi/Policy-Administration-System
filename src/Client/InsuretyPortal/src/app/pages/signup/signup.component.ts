import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css', './input-box.component.css'],
  providers: [AuthenticationService],
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;

  constructor(
    private authService: AuthenticationService,
    private formBuilder: FormBuilder
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

  ngOnInit(): void {
    this.formBuilder.group({
      name: 'Harsh Rastogi',
      userName: 'harshRastogi',
      password: '1234',
      email: 'harsh@example.com',
    });
  }

  async signup() {
    await this.authService.signup({
      name: this.signupForm.get('name')!.value,
      email: this.signupForm.get('email')!.value,
      userName: this.signupForm.get('userName')!.value,
      password: this.signupForm.get('password')!.value,
    });
  }

  onSubmit() {
    if (this.signupForm.valid) this.authService.signup(this.signupForm.value);
    else console.log('Invalid');
  }
}
