export enum PolicyStatus {
  Initiated,
}

export type Policy = {
  id: string;
  policyName: string;
  customerId: string;
  businessId: string;
  agentId: string;
  status: PolicyStatus;
};
