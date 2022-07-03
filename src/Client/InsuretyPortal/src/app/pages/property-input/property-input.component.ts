import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';

@Component({
  selector: 'app-property-input',
  templateUrl: './property-input.component.html',
  styleUrls: ['./property-input.component.css'],
})
export class PropertyInputComponent implements OnInit {
  businessID: string;
  private readonly _route: ActivatedRoute;
  private readonly _consumerservice: ConsumerService;
  private readonly _router: Router;
  createPropertyFrom: FormGroup;
  constructor(
    route: ActivatedRoute,
    _consumerservice: ConsumerService,
    _router: Router
  ) {
    this._route = route;
    this._consumerservice = _consumerservice;
    this._router = _router;
    this.createPropertyFrom = new FormGroup({
      businessID: new FormControl(this._route.snapshot.paramMap.get('id')),
      propertyType: new FormControl('', Validators.required),
      propertyAddress: new FormControl('', Validators.required),
      propertyArea: new FormControl('', Validators.required),
      propertybuildingStorey: new FormControl('', Validators.required),
      propertyAge: new FormControl('', Validators.required),
      propertyValue: new FormControl('', Validators.required),
    });
  }
  get isSubmitDisabled(): boolean {
    if (!this.createPropertyFrom.touched) return false;
    return this.createPropertyFrom.invalid;
  }

  ngOnInit(): void {
    this.businessID = this._route.snapshot.paramMap.get('id')!;
  }

  async createProperty() {
    if (this.createPropertyFrom.valid) {
      await this._consumerservice.addProperty(this.createPropertyFrom.value);
      alert('property created');
      this._router.navigate(['/customer']);
    }
  }
}
