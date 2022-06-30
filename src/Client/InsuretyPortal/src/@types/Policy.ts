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

// "id": "1460d501-599d-4b59-baf9-57cbb1e9c696",
//     "propertyType": "Building",
//     "customerType": 0,
//     "assuredSum": 200000,
//     "tenure": 3,
//     "businessValue": 8,
//     "propertyValue": 5,
//     "baseLocation": "Chennai",
//     "type": "Replacement"
