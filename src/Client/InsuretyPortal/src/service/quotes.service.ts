import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

const BaseUri = environment.serviceUri.quotes;

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

    if (response.status == 404) {
      throw new Error('NO_QUOTE_FOUND');
    }

    return response.json();
  }
}
