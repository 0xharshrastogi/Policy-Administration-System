import { Injectable } from '@angular/core';

const BaseUri = 'http://localhost:5189';
const PATH = {
  CREATE_POLICY: '/api/CreatePolicy',
  VIEW_POLICY: (id: string) => `/api/ViewPolicy?policyId=${id}`,
};

@Injectable({
  providedIn: 'root',
})
export class PolicyServiceService {
  constructor() {}
}
