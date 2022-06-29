import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
})
export class LoginFormComponent {
  loginForm: FormGroup;
  errors: Error[] = [];

  private readonly _auth: AuthenticationService;
  private readonly _router: Router;

  constructor(auth: AuthenticationService, router: Router) {
    this._auth = auth;
    this._router = router;

    this.loginForm = new FormGroup({
      userName: new FormControl(''),
      password: new FormControl('', [
        Validators.required,
        Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/),
      ]),
    });
  }

  get isError(): boolean {
    return this.errors.length > 0;
  }

  get errorMessage(): string {
    return this.errors.map((error) => error.message).join('\n');
  }

  get isSubmitDisabled(): boolean {
    if (!this.loginForm.touched) return false;
    return this.loginForm.invalid;
  }
  async onSubmit() {
    try {
      const { value: credential } = this.loginForm;
      await this._auth.login(credential);
      this._router.navigate(['/customer']);
    } catch (error) {
      this.errors.push(<Error>error);
    }
  }
}
