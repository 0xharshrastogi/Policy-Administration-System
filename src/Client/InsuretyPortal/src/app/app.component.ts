import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/service/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  private readonly authService: AuthenticationService;

  title = 'Insurity';

  /**
   *
   */
  constructor(authservice: AuthenticationService) {
    this.authService = authservice;
  }

  async ngOnInit() {
    this.authService.validate().then(console.dir).catch(console.dir);
  }
}
