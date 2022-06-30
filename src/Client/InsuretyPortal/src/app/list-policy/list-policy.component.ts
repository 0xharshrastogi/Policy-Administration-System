import { Component, OnInit } from '@angular/core';
import { Policy } from 'src/@types/Policy';
import { PolicyService } from 'src/service/policy-service.service';

@Component({
  selector: 'app-list-policy',
  templateUrl: './list-policy.component.html',
  styleUrls: ['./list-policy.component.css'],
})
export class ListPolicyComponent implements OnInit {
  policies: Policy[] = [];
  isLoaded: boolean = false;

  private readonly policyService: PolicyService;

  constructor(pService: PolicyService) {
    this.policyService = pService;
  }

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    const policies = await this.policyService.fetchPolicy();

    if (Array.isArray(policies)) {
      this.policies = policies;
      this.isLoaded = true;
    }
  }
}
