import { Injectable } from '@angular/core';

const BaseUri = 'http://localhost:5032';

const PATH = {
  GET_QUOTES: (
    propertyValue: string,
    businessValue: string,
    propertyType: string
  ) =>
    `${BaseUri}/Quotes?businessValue=${businessValue}&propertyValue=${propertyValue}&propertyType=${propertyType}`,
};

@Injectable({
  providedIn: 'root',
})
export class QuotesService {
  async fetchQuotes(
    propertyValue: string,
    businessValue: string,
    propertyType: string
  ) {
    const response = await fetch(
      PATH.GET_QUOTES(propertyValue, businessValue, propertyType),
      {
        headers: {
          'Content-Type': 'application/json',
          accept: '*/*',
        },
      }
    );

    return response.json();
  }
}
