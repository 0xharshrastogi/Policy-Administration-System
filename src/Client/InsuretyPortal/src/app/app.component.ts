import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  private readonly authService: AuthenticationService;

  title = 'InsuretyPortal';

  /**
   *
   */
  constructor(authservice: AuthenticationService) {
    this.authService = authservice;
  }

  async ngOnInit() {}
}
