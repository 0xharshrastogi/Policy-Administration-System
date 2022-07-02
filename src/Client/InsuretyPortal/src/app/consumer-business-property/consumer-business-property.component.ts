import { NullVisitor } from '@angular/compiler/src/render3/r3_ast';
import { Component, Input, OnInit } from '@angular/core';
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
  property: Property | null = null;

  private readonly consumerservice: ConsumerService;
  private readonly router: Router;

  constructor(_consumerservice: ConsumerService, router: Router) {
    this.consumerservice = _consumerservice;
    this.router = router;
  }

  async ngOnInit(): Promise<void> {
    this.property = await this.consumerservice.fetchPropertyBycustomerrID(
      this.customerID
    );
    console.log(this.property);
  }
  gotoPropertyInput(businessID: string) {
    this.router.navigate([`customer-view/${businessID}/AddProperty`]);
  }
}
