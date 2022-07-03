import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  @Input() title: string;

  isNavbarCollapsed: boolean = true;

  constructor(
    private readonly _auth: AuthenticationService,
    private readonly _router: Router
  ) {}

  get isLoggedIn(): boolean {
    return this._auth.isLoggedIn;
  }

  toogleNavbarCollapse() {
    this.isNavbarCollapsed = !this.isNavbarCollapsed;
  }

  async signout() {
    await this._auth.signout();
    this._router.navigate(['/login']);
  }
}
