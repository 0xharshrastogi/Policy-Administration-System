import { Injectable } from '@angular/core';
import { Policy } from 'src/@types/Policy';

const BaseUri = 'http://localhost:5189';

const PATH = {
  CREATE_POLICY: `${BaseUri}/api/CreatePolicy`,
  VIEW_POLICY_BY_ID: (id: string) => `${BaseUri}/api/ViewPolicy?policyId=${id}`,
  VIEW_POLICY_ALL: `${BaseUri}/api/ViewPolicy`,
  ISSUE_POLICY: (id: string) => `${BaseUri}/api/IssuePolicy/${id}`,
  POLICY_MASTER_BY_B_VAL: (id: string) =>
    `${BaseUri}/api/GetPoliciesByBusinessValue?businessValue=${id}`,
};

type HttpAction = 'GET' | 'PUT' | 'POST' | 'DELETE';

@Injectable({
  providedIn: 'root',
})
export class PolicyService {
  constructor() {}

  private async _fetchAll(): Promise<Policy[]> {
    const response = await fetch(PATH.VIEW_POLICY_ALL, {
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    return <Promise<Policy[]>>response.json();
  }

  private async _fetchById(id: string): Promise<Policy | null> {
    const response = await fetch(PATH.VIEW_POLICY_BY_ID(id), {
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    return response.json();
  }

  /**
   * If id is passed then it fetch particular policy else it fetched all policies
   * @param id?
   * @returns
   */
  async fetchPolicy(id?: string): Promise<Policy[] | (Policy | null)> {
    return id ? this._fetchById(id) : this._fetchAll();
  }

  async getPolicyMastersByBusinessValue(businessId: string) {
    const response = await fetch(PATH.POLICY_MASTER_BY_B_VAL(businessId), {
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    return response.json();
  }
}
