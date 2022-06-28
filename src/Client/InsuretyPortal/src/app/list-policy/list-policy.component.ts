import { Component, OnInit } from '@angular/core';

type Policy = {
  id: string;
  customerId: string;
  businessId: string;
  agentId: string;
  status: 'Initiated' | 'Issued';
};

@Component({
  selector: 'app-list-policy',
  templateUrl: './list-policy.component.html',
  styleUrls: ['./list-policy.component.css'],
})
export class ListPolicyComponent implements OnInit {
  policies: Policy[] = [];

  isLoaded: boolean = false;

  constructor() {}

  async ngOnInit(): Promise<void> {
    const uri = 'http://localhost:5189/api/ViewPolicy';

    const result = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });

    this.policies = await result.json();
    this.isLoaded = true;
    console.log(this.policies);
  }
}
