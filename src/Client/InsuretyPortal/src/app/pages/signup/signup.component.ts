import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  providers: [AuthenticationService],
})
export class SignupComponent implements OnInit {
  signupFG = new FormGroup({
    name: new FormControl('', Validators.required),
    userName: new FormControl([
      '',
      Validators.required,
      Validators.minLength(5),
    ]),
    password: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
  });

  constructor(private authService: AuthenticationService) {}

  ngOnInit(): void {}

  async signup() {
    await this.authService.login({
      name: this.signupFG.get('name')!.value,
      email: this.signupFG.get('email')!.value,
      userName: this.signupFG.get('userName')!.value,
      password: this.signupFG.get('password')!.value,
    });
  }

  onSubmit() {
    console.log('hello');
  }
}
