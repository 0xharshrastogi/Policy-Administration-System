import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-input',
  templateUrl: './property-input.component.html',
  styleUrls: ['./property-input.component.css'],
})
export class PropertyInputComponent implements OnInit {
  BusinessID: string;
  private readonly _route: ActivatedRoute;
  constructor(route: ActivatedRoute) {
    this._route = route;
  }

  ngOnInit(): void {
    this.BusinessID = this._route.snapshot.paramMap.get('businessID')!;
    // alert(this.BusinessID);
  }
}
