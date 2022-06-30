import { Injectable } from '@angular/core';
import { HttpStatusCode } from 'src/utils/HttpStatusCode';

type Customer = {
  customerName: string;
  dateOfBirth: Date;
  email: string;
  pan: string;
};

type SignUpCredential = Credential & { name: string; email: string };

@Injectable({
  providedIn: 'root',
})
export class ConsumerService {
  static BaseAuthUri = 'http://localhost:5114';
  static requestPath = {
    FETCH_CONSUMER_BUSINESS: `${ConsumerService.BaseAuthUri}/Consumer/getBusinessByCustomerID`,
    ADD_CUSTOMER: `${ConsumerService.BaseAuthUri}/Consumer`,
  };
  async fetchConsumerBusiness(customerID: string) {
    const uri =
      ConsumerService.requestPath.FETCH_CONSUMER_BUSINESS +
      `?customerID=${customerID}`;
    const response = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
    console.log(response);
    return response.json();
  }
  async addcustomer(customer: Customer) {
    const uri = ConsumerService.requestPath.ADD_CUSTOMER;
    const response = await fetch(uri, {
      method: 'POST',
      credentials: 'same-origin',
      body: JSON.stringify(customer),
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
    if (response.status === HttpStatusCode.Created)
      console.log(`${response.status} created`);
    else console.log(`${response.status} not created`);
  }
}
