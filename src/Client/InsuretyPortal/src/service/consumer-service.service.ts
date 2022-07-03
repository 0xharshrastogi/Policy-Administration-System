import { Injectable } from '@angular/core';
import { Consumer } from 'src/@types/Customer';
import { environment } from 'src/environments/environment';
import { HttpStatusCode } from 'src/utils/HttpStatusCode';

type Customer = {
  customerName: string;
  dateOfBirth: Date;
  email: string;
  pan: string;
};
type Business = {
  customerID: string;
  businessName: string;
  businessType: number;
  totalEmployees: number;
  annualTurnover: number;
  businessValue: number;
};
type Businessupdatetype = {
  BusinessID: string;
  businessName: string;
  businessType: number;
  totalEmployees: number;
  annualTurnover: number;
  businessValue: number;
};
type Property = {
  businessID: string;
  propertyType: string;
  address: string;
  area: string;
  buildingStorey: number;
  age: number;
  propertyValue: number;
};

@Injectable({
  providedIn: 'root',
})
export class ConsumerService {
  static BaseAuthUri = environment.serviceUri.consumer;

  static requestPath = {
    FETCH_CONSUMER_BUSINESS_BY_ID: `${ConsumerService.BaseAuthUri}/Consumer/getBusinessByCustomerID`,
    ADD_CUSTOMER: `${ConsumerService.BaseAuthUri}/Consumer/Customer`,
    ADD_BUSINESS: `${ConsumerService.BaseAuthUri}/Consumer/Business`,
    ADD_PROPERTY: `${ConsumerService.BaseAuthUri}/Consumer/Property`,
    UPDATE_CUSTOMER: `${ConsumerService.BaseAuthUri}/Consumer/Customer`,
    UPDATE_BUSINESS: `${ConsumerService.BaseAuthUri}/Consumer/Business`,
    UPDATE_Property: `${ConsumerService.BaseAuthUri}/Consumer/Property`,
    DELETE_CUSTOMER: `${ConsumerService.BaseAuthUri}/Consumer/Customer`,
    DELETE_BUSINESS: `${ConsumerService.BaseAuthUri}/Consumer/Business`,
    DELETE_Property: `${ConsumerService.BaseAuthUri}/Consumer/Property`,
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
    console.log(`${response}`);
    if (response.status === HttpStatusCode.Created)
      console.log(`${response.status} created`);
    else console.log(`${response.status} not created`);
  }
  async addBusiness(business: Business) {
    const uri = ConsumerService.requestPath.ADD_BUSINESS;
    const response = await fetch(uri, {
      method: 'POST',
      credentials: 'same-origin',
      body: JSON.stringify(business),
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
    var addStatus = false;
    addStatus = response.status === HttpStatusCode.Created ? true : false;
    return addStatus;
  }
  async addProperty(property: Property) {
    console.log('addproperty method invoked');
    const uri = ConsumerService.requestPath.ADD_PROPERTY;
    const response = await fetch(uri, {
      method: 'POST',
      credentials: 'same-origin',
      body: JSON.stringify(property),
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
    var addStatus = false;
    addStatus = response.status === HttpStatusCode.Created ? true : false;

    return addStatus;
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

  async updatecustomer(customer: Customer) {
    const uri = ConsumerService.requestPath.UPDATE_CUSTOMER;
    const response = await fetch(uri, {
      method: 'PUT',
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
  async updateBusiness(business: Businessupdatetype) {
    const uri = ConsumerService.requestPath.UPDATE_BUSINESS;
    const response = await fetch(uri, {
      method: 'PUT',
      credentials: 'same-origin',
      body: JSON.stringify(business),
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });
    if (response.status === HttpStatusCode.Created)
      console.log(`${response.status} created`);
    else console.log(`${response.status} not created`);
  }
  async updateProperty(property: Property) {
    const uri = ConsumerService.requestPath.UPDATE_Property;
    const response = await fetch(uri, {
      method: 'PUT',
      credentials: 'same-origin',
      body: JSON.stringify(property),
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
