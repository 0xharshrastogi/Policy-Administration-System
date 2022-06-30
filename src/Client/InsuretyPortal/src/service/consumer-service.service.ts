import { Injectable } from '@angular/core';
import { Consumer } from 'src/@types/Customer';
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
    FETCH_CONSUMER_BUSINESS_BY_ID: `${ConsumerService.BaseAuthUri}/Consumer/getBusinessByCustomerID`,
    ADD_CUSTOMER: `${ConsumerService.BaseAuthUri}/Consumer/Customer`,
    FETCH_CONSUMER_BUSINESS_ALL: `${ConsumerService.BaseAuthUri}/Consumer/Customer`,
    GET_PROPERTIES_BY_CUSTOMER_ID: `${ConsumerService.BaseAuthUri}/Consumer/GetPropertyByCustomerID`,
  };

  async fetchPropertyBycustomerrID(customerID: string) {
    const uri =
      ConsumerService.requestPath.GET_PROPERTIES_BY_CUSTOMER_ID +
      `?customerID=${customerID}`;
    const response = await fetch(uri, {
      method: `GET`,
      credentials: `same-origin`,
      headers: {
        'content-Type': 'application/json',
        accept: '*/*',
      },
    });
    return response.json();
  }

  async fetchConsumerBusinessByID(customerID: string) {
    const uri =
      ConsumerService.requestPath.FETCH_CONSUMER_BUSINESS_BY_ID +
      `?customerID=${customerID}`;
    const response = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
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

  async fetchConsumers(): Promise<Consumer[]> {
    const response = await fetch(
      ConsumerService.requestPath.FETCH_CONSUMER_BUSINESS_ALL,
      {
        headers: { 'Content-Type': 'application/json', accept: '*/*' },
      }
    );

    return response.json();
  }
}
