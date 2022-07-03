import { NullVisitor } from '@angular/compiler/src/render3/r3_ast';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';
type Property = {
  propertyID: string;
  businessID: string;
  business: null;
  propertyType: number;
  address: string;
  areaInSqFt: 0;
  buildingStorey: 0;
  buildingAge: 0;
  propertyValue: 0;
};
@Component({
  selector: 'app-consumer-business-property',
  templateUrl: './consumer-business-property.component.html',
  styleUrls: ['./consumer-business-property.component.css'],
})
export class ConsumerBusinessPropertyComponent implements OnInit {
  @Input() customerID: string;
  @Input() businessID: string;
  _property: Property | null = null;

  private readonly consumerservice: ConsumerService;
  private readonly router: Router;
  updatePropertyForm: FormGroup;
  constructor(_consumerservice: ConsumerService, router: Router) {
    this.consumerservice = _consumerservice;
    this.router = router;
  }

  async ngOnInit(): Promise<void> {
    const property = await this.consumerservice.fetchPropertyBycustomerrID(
      this.customerID
    );
    console.log(property);
    this._property = property;
    this.updatePropertyForm = new FormGroup({
      propertyID: new FormControl(this._property?.propertyID),
      propertyType: new FormControl(this._property?.propertyType),
      Address: new FormControl(this._property?.address),
      propertyArea: new FormControl(this._property?.areaInSqFt),
      buildingStorey: new FormControl(this._property?.buildingStorey),
      propertyValue: new FormControl(this._property?.propertyValue),
    });
  }
  gotoPropertyInput(businessID: string) {
    this.router.navigate([`customer-view/${businessID}/AddProperty`]);
  }
  async updateProperty() {
    if (this.updatePropertyForm.valid) {
      var response = await this.consumerservice.updateProperty(
        this.updatePropertyForm.value
      );
      alert('property Updated');
    } else {
      alert('invalid response');
    }
  }
}
