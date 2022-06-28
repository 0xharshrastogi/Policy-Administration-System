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
  static BaseAuthUri = 'http://localhost:5090/api';

  static requestPath = {
    SIGNUP: `${AuthenticationService.BaseAuthUri}/auth/agent/signup`,
    VALIDATE: `${AuthenticationService.BaseAuthUri}/auth/agent/validate`,
  };

  constructor() {}

  async signup(credential: SignUpCredential) {
    const uri = 'http://localhost:5090/api/Auth/Agent/Signup';

    try {
      const response = await fetch(uri, {
        method: 'POST',
        body: JSON.stringify(credential),
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          accept: '*/*',
        },
      });

      if (response.status === HttpStatusCode.Created) return;
    } catch (error) {
      console.log(error);
    }
  }

  async validate() {
    const response = await fetch(AuthenticationService.requestPath.VALIDATE, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        Cookie: document.cookie,
      },
    });
    console.log(response);
  }
}
