export enum PolicyStatus {
  Initiated,
}

export type Policy = {
  id: string;
  policyName: string;
  customerId: string;
  businessId: string;
  agentId: string;
  status: string;
};

export type PolicyMaster = {
  id: string;
  propertyType: string;
  customerType: number;
  assuredSum: number;
  tenure: number;
  businessValue: number;
  propertyValue: number;
  baseLocation: string;
  type: string;
};

export type IssuePolicyCreate = {
  policyId: string;
  paymentStatus: string;
  effectiveDate: string;
  coveredSum: number;
  duration: number;
};

export enum PaymentStatus {
  Pending = 0,

  Complete = 1,

  Refunded = 2,

  Failed = 3,

  Abandoned = 4,

  Cancelled = 5,
}
