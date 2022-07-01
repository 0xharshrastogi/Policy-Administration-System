export type Consumer = {
  customerID: string;
  customerName: string;
  dateOfBirth: string;
  phoneNumber: number;
  pan: string;
};

export type Business = {
  businessID: string;
  customerID: string;
  businessName: string;
  businessValue: number;
};

export type BusinessProperty = {
  propertyID: string;
  businessID: string;
  propertyType: number;
  address: string;
  areaInSqFt: number;
  buildingStorey: number;
  buildingAge: number;
  propertyValue: number;
};
