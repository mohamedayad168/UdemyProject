export type User = {
  id?: number;
  email: string;
  userName?: string;
  firstName: string;
  lastName: string;
  countryName: string;
  city: string;
  state: string;
  age: number;
  gender: string;
  phoneNumber: string;
  roles?: [string];
};
