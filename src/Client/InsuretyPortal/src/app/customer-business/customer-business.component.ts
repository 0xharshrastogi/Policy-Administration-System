import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';

type Business = {
  businessID: string;
  customerID: string;
  customer: null;
  businessTypeID: string;
  businessMaster: null;
  totalEmployees: number;
  annualTurnover: number;
  businessValue: number;
  message: string;
};

@Component({
  selector: 'app-customer-business',
  templateUrl: './customer-business.component.html',
  styleUrls: ['./customer-business.component.css'],
})
export class CustomerBusinessComponent implements OnInit {
  @Input() customerID: string = '';
  isLoading: boolean = true;
  _business: Business | null = null;

  private readonly _cservice: ConsumerService;
  private readonly _router: Router;

  constructor(cservice: ConsumerService, router: Router) {
    this._cservice = cservice;
    this._router = router;
  }

  /*  get businessjsonvalue() {
    return JSON.stringify(this.business);
  }*/

  async ngOnInit(): Promise<void> {
    const business = await this._cservice.fetchConsumerBusinessByID(
      this.customerID
    );
    this._business = business;
    console.log(this._business?.message);
    this.isLoading = false;
  }

  gotobusinessform(customerID: string) {
    this._router.navigate([`customer-view/${customerID}/Addbusiness`]);
  }
}
