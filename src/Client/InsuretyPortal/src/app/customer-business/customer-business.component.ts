import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';
import { HttpStatusCode } from 'src/utils/HttpStatusCode';

type Business = {
  businessID: string;
  customerID: string;
  customer: null;
  businessName: string;
  businessType: number;
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
  @Input() onPropertGet: (id: string) => void;
  @Input() customerID: string = '';
  isLoading: boolean = true;
  _business: Business | null = null;

  private readonly _cservice: ConsumerService;
  private readonly _router: Router;
  updateBusinessForma: FormGroup;
  constructor(cservice: ConsumerService, router: Router) {
    this._cservice = cservice;
    this._router = router;
  }
  get isUpdateDisabled(): boolean {
    if (this.updateBusinessForma.valid) return false;
    else return true;
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
    this.updateBusinessForma = new FormGroup({
      BusinessID: new FormControl(this._business!.businessID),
      businessName: new FormControl(this._business?.businessName),
      businessType: new FormControl(this._business?.businessType),
      totalEmployees: new FormControl(this._business?.totalEmployees),
      annualTurnover: new FormControl(this._business?.annualTurnover),
      businessValue: new FormControl(this._business?.businessValue),
    });
  }

  gotobusinessform(customerID: string) {
    this._router.navigate([`customer-view/${customerID}/Addbusiness`]);
  }
  async updateBusiness() {
    if (this.updateBusinessForma.valid) {
      var response = await this._cservice.updateBusiness(
        this.updateBusinessForma.value
      );
      alert('Business Updated');
    } else {
      alert('invalid response');
    }
  }
}
