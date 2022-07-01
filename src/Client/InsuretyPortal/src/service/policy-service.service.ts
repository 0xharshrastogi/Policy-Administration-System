import { Injectable } from '@angular/core';
import { IssuePolicyCreate, Policy } from 'src/@types/Policy';

const BaseUri = 'http://localhost:5189';

const PATH = {
  CREATE_POLICY: `${BaseUri}/api/CreatePolicy`,
  VIEW_POLICY_BY_ID: (id: string) => `${BaseUri}/api/ViewPolicy?policyId=${id}`,
  VIEW_POLICY_ALL: `${BaseUri}/api/ViewPolicy`,
  POLICY_MASTER_BY_B_VAL: (id: string) =>
    `${BaseUri}/api/GetPoliciesByBusinessValue?businessValue=${id}`,
  ISSUE_POLICY: (id: string | number) => `${BaseUri}/api/IssuePolicy/${id}`,
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

  async createPolicy(policy: Policy) {
    const response = await fetch(PATH.CREATE_POLICY, {
      method: 'POST',
      body: JSON.stringify(policy),
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    return response.json();
  }

  async issuePolicy(id: string, issueData: IssuePolicyCreate) {
    const response = await fetch(PATH.ISSUE_POLICY(id), {
      method: 'PUT',
      body: JSON.stringify(issueData),
      headers: { 'Content-Type': 'application/json', accept: '*/*' },
    });

    return response.json();
  }
}
