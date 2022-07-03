import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ConsumerService } from 'src/service/consumer-service.service';

type Customer = {
  customerID: string;
  customerName: string;
  dateOfBirth: string;
  email: string;
  pan: string;
};
@Component({
  selector: 'app-customer-view',
  templateUrl: './customer-view.component.html',
  styleUrls: ['./customer-view.component.css'],
})
export class CustomerViewComponent implements OnInit {
  customer: Customer | null = null;
  isLoading: boolean = true;
  private readonly service: ConsumerService;
  constructor(private router: ActivatedRoute, cservice: ConsumerService) {
    this.service = cservice;
  }
  updateCustomerForm: FormGroup;
  async ngOnInit(): Promise<void> {
    const customerId = this.router.snapshot.paramMap.get('id');
    console.log(customerId);
    const uri = `${environment.serviceUri.consumer}/Consumer/Customer?id=${customerId}`;
    this.isLoading = true;
    const result = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });

    this.customer = await result.json();
    this.isLoading = false;
    console.log(this.customer);
    this.updateCustomerForm = new FormGroup({
      customerID: new FormControl(this.customer?.customerID),
      customerName: new FormControl(this.customer?.customerName),
      dateOfBirth: new FormControl(this.toDate()),
      Email: new FormControl(this.customer?.email),
      panDetails: new FormControl(this.customer?.pan),
    });
  }

  toDate(): string {
    const dob = new Date(this.customer!.dateOfBirth);
    const date = dob;
    const YYYY = date.getFullYear();
    const month = date.getMonth() + 1;
    const datenum = date.getDate();

    const dd = datenum <= 9 ? '0' + datenum.toString() : datenum.toString();
    const MM = month <= 9 ? '0' + month.toString() : month.toString();

    return `${YYYY}-${MM}-${dd}`;
  }

  async updateCustomer() {
    console.log(this.updateCustomerForm.value);
    if (this.updateCustomerForm.valid) {
      // console.log(this.updateCustomerForm.value);
      const response = await this.service.updatecustomer(
        this.updateCustomerForm.value
      );
      console.log(response);
      alert('consumer updated');
    } else {
      alert('customer not updated');
    }
  }
}
