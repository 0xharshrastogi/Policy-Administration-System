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
  static authUri = 'http://localhost:5090';

  constructor() {}

  async login(credential: SignUpCredential) {
    const response = await fetch(AuthenticationService.authUri, {
      method: 'POST',
      body: JSON.stringify(credential),
    });

    if (response.status === HttpStatusCode.Created) return;
  }
}
