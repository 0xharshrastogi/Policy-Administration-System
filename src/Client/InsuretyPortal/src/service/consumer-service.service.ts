import { Injectable } from '@angular/core';

type Credential = {
  userName: string;
  password: string;
};

type SignUpCredential = Credential & { name: string; email: string };

@Injectable({
  providedIn: 'root',
})
export class ConsumerService {
  static BaseAuthUri = 'http://localhost:5114';
  static requestPath = {
    FETCH_CONSUMER_BUSINESS: `${ConsumerService.BaseAuthUri}/Consumer/getBusinessByCustomerID`,
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
}
