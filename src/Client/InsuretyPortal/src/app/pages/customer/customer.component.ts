import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
type customer = {
  customerID: string;
  customerName: string;
  dateOfBirth: Date;
  email: string;
  pan: string;
};

var x = '';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  customers: customer[] = [];
  isLoaded: boolean = false;

  constructor(private router : Router) {

  }

  async ngOnInit(): Promise<void> {
    const uri = 'http://localhost:5114/Consumer';

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

  onClick(id :string)
  {
    this.router.navigate([`/customer-view/${id}`])
  }
}
