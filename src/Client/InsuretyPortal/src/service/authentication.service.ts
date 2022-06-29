import { Injectable } from '@angular/core';
import { HttpStatusCode } from 'src/utils/HttpStatusCode';

type Credential = {
  userName: string;
  password: string;
};

type SignUpCredential = Credential & { name: string; email: string };

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  static isSignedIn: boolean = false;

  static BaseAuthUri = 'http://localhost:5090/api';

  static requestPath = {
    SIGNUP: `${AuthenticationService.BaseAuthUri}/auth/agent/signup`,
    VALIDATE: `${AuthenticationService.BaseAuthUri}/auth/agent/validate`,
    LOGIN: `${AuthenticationService.BaseAuthUri}/auth/agent/login`,
  };

  constructor() {}

  get isLoggedIn(): boolean {
    return AuthenticationService.isSignedIn;
  }

  async signup(credential: SignUpCredential) {
    const uri = 'http://localhost:5090/api/Auth/Agent/Signup';

    const response = await fetch(uri, {
      method: 'POST',
      body: JSON.stringify(credential),
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });

    if (response.status === HttpStatusCode.Created) {
      const { auth_token: token } = await response.json();
      localStorage.setItem('token', token);
      AuthenticationService.isSignedIn = true;
    }
  }

  async login(credential: Credential): Promise<boolean> {
    const response = await fetch(AuthenticationService.requestPath.LOGIN, {
      method: 'POST',
      body: JSON.stringify(credential),
      credentials: 'same-origin',
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    const { auth_token: token } = await response.json();
    localStorage.setItem('token', token);
    AuthenticationService.isSignedIn = true;
    return true;
  }

  async validate(): Promise<true | false> {
    const response = await fetch(AuthenticationService.requestPath.VALIDATE, {
      method: 'POST',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
      body: JSON.stringify({
        token: localStorage.getItem('token') ?? '',
      }),
    });

    const isValidated = response.status === HttpStatusCode.Ok ? true : false;

    if (isValidated) {
      AuthenticationService.isSignedIn = true;
    } else {
      AuthenticationService.isSignedIn = false;
      localStorage.removeItem('token');
    }

    return isValidated;
  }
}
