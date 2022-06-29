import { Component, Input } from '@angular/core';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  @Input() title: string;

  isNavbarCollapsed: boolean = false;

  private readonly _auth: AuthenticationService;

  constructor(auth: AuthenticationService) {
    this._auth = auth;
  }

  get isLoggedIn(): boolean {
    return this._auth.isLoggedIn;
  }

  toogleNavbarCollapse() {
    this.isNavbarCollapsed = !this.isNavbarCollapsed;
  }
}
