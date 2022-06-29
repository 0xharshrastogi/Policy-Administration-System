import { Component, Input, OnInit } from '@angular/core';
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
};

@Component({
  selector: 'app-customer-business',
  templateUrl: './customer-business.component.html',
  styleUrls: ['./customer-business.component.css'],
})
export class CustomerBusinessComponent implements OnInit {
  @Input() customerID: string = '';
  isLoading: boolean = true;
  business: Business | null = null;

  private readonly _cservice: ConsumerService;

  constructor(cservice: ConsumerService) {
    this._cservice = cservice;
  }

  get businessjsonvalue() {
    return JSON.stringify(this.business);
  }

  async ngOnInit(): Promise<void> {
    const business = await this._cservice.fetchConsumerBusiness(
      this.customerID
    );
    this.business = business;
    this.isLoading = false;
  }
}
