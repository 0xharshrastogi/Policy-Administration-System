import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Business, BusinessProperty, Consumer } from 'src/@types/Customer';
import { PolicyMaster } from 'src/@types/Policy';
import { Quotes } from 'src/@types/Quotes';
import { ConsumerService } from 'src/service/consumer-service.service';
import { PolicyService } from 'src/service/policy-service.service';
import { QuotesService } from 'src/service/quotes.service';

interface ChangeEvent extends Event {
  target: EventTarget & {
    value: string;
  };
}

type BusinessState = {
  found: boolean;
  value: any | null;
  isLoading: boolean;
  _isFetchedAtLeastOnce: boolean;

  HasFetchedOnce(): void;
};

@Component({
  selector: 'app-create-policy',
  templateUrl: './create-policy.component.html',
  styleUrls: ['./create-policy.component.css'],
})
export class CreatePolicyComponent implements OnInit {
  consumers: Consumer[];
  property: BusinessProperty;
  selectedCustomerId: string;
  business: BusinessState = {
    found: false,
    value: null,
    isLoading: false,
    _isFetchedAtLeastOnce: false,

    HasFetchedOnce() {
      this._isFetchedAtLeastOnce = true;
    },
  };
  policiesMaster = <PolicyMaster[]>[];
  selectedPolicyMaster: PolicyMaster | null;
  policyCreateForm: FormGroup;
  quotes: Quotes[] | null;

  canCreatePolicy = false;

  private readonly consumerService: ConsumerService;
  private readonly policyService: PolicyService;
  private readonly quoteService: QuotesService;

  constructor(
    cService: ConsumerService,
    pService: PolicyService,
    qService: QuotesService
  ) {
    this.consumerService = cService;
    this.policyService = pService;
    this.quoteService = qService;

    this.policyCreateForm = new FormGroup({
      policyName: new FormControl('', Validators.required),
      customerId: new FormControl('', Validators.required),
      businessId: new FormControl('', Validators.required),
      agentId: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.assignCustomerId();
  }

  async fetchQuotes(
    businessValue: number,
    propertyValue: number,
    propertyType: string
  ) {
    try {
      const quotes = await this.quoteService.fetchQuotes(
        businessValue.toString(),
        propertyValue.toString(),
        propertyType
      );
      this.quotes = quotes;
    } catch (error) {
      if ((<Error>error).message === 'NO_QUOTE_FOUND') {
        this.quotes = null;
      }
    }
  }

  async onCustomerIdChange(e: Event) {
    this.canCreatePolicy = false;
    const consumerId = (<ChangeEvent>e).target.value;

    try {
      this.business.isLoading = true;

      const property: BusinessProperty & { business: Business } =
        await this.consumerService.fetchPropertyBycustomerrID(consumerId);

      const { business } = property;
      this.property = property;

      // this.fetchQuotes(business, property);

      const isBusinessNotFound =
        'message' in business &&
        (<any>business).message === 'no business found';

      if (isBusinessNotFound) {
        this.selectedCustomerId = consumerId;
        throw new Error('NO_BUSINESS');
      }

      this.business.found = true;
      this.business.value = business;
      // !IMPORTANT DELETE NEXT LINE
      // this.onBusinessValue(8);
      this.onBusinessValue(business.businessValue);
    } catch (error) {
      if ((<Error>error).message === 'NO_BUSINESS') {
        this.business.value = null;
        this.business.found = false;
      }
    } finally {
      this.business.isLoading = false;
      this.business.HasFetchedOnce();
      this.policiesMaster = [];
    }
  }

  async onBusinessValue(value: number) {
    const policyMasters =
      await this.policyService.getPolicyMastersByBusinessValue(
        value.toString()
      );
    this.policiesMaster = policyMasters;
  }

  onSelectPolicyMaster(value: PolicyMaster) {
    this.selectedPolicyMaster = value;

    this.fetchQuotes(
      value.businessValue,
      value.propertyValue,
      value.propertyType
    );
  }

  onQuoteSelect(quote: Quotes) {
    console.log(quote);
    this.canCreatePolicy = true;
  }

  private async assignCustomerId() {
    const consumers = await this.consumerService.fetchConsumers();
    this.consumers = consumers;
  }

  getBusinessCreateUrl() {
    return `/customer-view/${this.selectedCustomerId}/Addbusiness`;
  }

  onSubmit() {
    this.policyCreateForm.controls['businessId'].setValue(
      this.property.businessID
    );

    this.policyCreateForm.controls['agentId'].setValue(
      '687ccaa4-4e7b-4b8a-b93e-e3c96f9d9bf1'
    );

    this.policyCreateForm.controls['policyName'].setValue(
      `Policy-${new Date().getTime()}`
    );

    this.policyService.createPolicy(this.policyCreateForm.value);
  }
}
