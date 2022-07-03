import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
type customer = {
  customerID: string;
  customerName: string;
  dateOfBirth: Date;
  email: string;
  pan: string;
};

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  customers: customer[] = [];
  isLoaded: boolean = false;

  constructor(private router: Router) {}

  async ngOnInit(): Promise<void> {
    const uri = `${environment.serviceUri.consumer}/Consumer/Customer`;

    const result = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });

    this.customers = await result.json();
    this.isLoaded = true;
    console.log(this.customers);
  }

  onClick(id: string) {
    this.router.navigate([`/customer-view/${id}`]);
  }

  onaddcustomer() {
    this.router.navigate([`/customerinput`]);
  }
}
