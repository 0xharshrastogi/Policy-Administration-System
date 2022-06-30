import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-business-input',
  templateUrl: './business-input.component.html',
  styleUrls: ['./business-input.component.css'],
})
export class BusinessInputComponent implements OnInit {
  customerID: string;

  private readonly _router: ActivatedRoute;

  constructor(activedRoute: ActivatedRoute) {
    this._router = activedRoute;
  }

  ngOnInit(): void {
    this.customerID = this._router.snapshot.paramMap.get('id')!;
  }
}
