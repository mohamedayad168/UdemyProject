export interface IAdmin {
  id: string;
  email: string;
  userName: string;
  firstName: string;
  lastName: string;
  countryName: string;
  city: string;
  state: string;
  age: number;
  gender: string;
  roles: string[];
}
export interface IAdminCDTO {
  email: string;
  userName: string;
  firstName: string;
  lastName: string;
  countryName: string;
  city: string;
  state: string;
  age: number;
  gender: string;
}
