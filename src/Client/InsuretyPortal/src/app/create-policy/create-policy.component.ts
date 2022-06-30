import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Consumer } from 'src/@types/Customer';
import { PolicyMaster } from 'src/@types/Policy';
import { ConsumerService } from 'src/service/consumer-service.service';
import { PolicyService } from 'src/service/policy-service.service';

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

  private readonly consumerService: ConsumerService;
  private readonly policyService: PolicyService;

  constructor(cService: ConsumerService, pService: PolicyService) {
    this.consumerService = cService;
    this.policyService = pService;

    this.policyCreateForm = new FormGroup({
      customerId: new FormControl('', Validators.required),
      businessId: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.assignCustomerId();
  }

  async onCustomerIdChange(e: Event) {
    const consumerId = (<ChangeEvent>e).target.value;

    try {
      this.business.isLoading = true;

      const business = await this.consumerService.fetchConsumerBusinessByID(
        consumerId
      );

      const isBusinessNotFound =
        'message' in business && business.message === 'no business found';

      if (isBusinessNotFound) {
        this.selectedCustomerId = consumerId;
        throw new Error('NO_BUSINESS');
      }

      this.business.found = true;
      this.business.value = business;
      // !IMPORTANT DELETE NEXT LINE
      this.onBusinessValue(8);
      // this.onBusinessValue(business.businessValue);
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
    console.log(policyMasters);
    this.policiesMaster = policyMasters;
  }

  onSelectPolicyMaster(value: PolicyMaster) {
    this.selectedPolicyMaster = value;
    console.log(this.selectedPolicyMaster);
  }

  private async assignCustomerId() {
    const consumers = await this.consumerService.fetchConsumers();
    this.consumers = consumers;
  }

  getBusinessCreateUrl() {
    return `/customer-view/${this.selectedCustomerId}/Addbusiness`;
  }
}
