export interface IStudent {
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
  title: string;
  bio: string;
  wallet: number;
}
export interface IStudentCDTO {
  email: string;
  userName: string;
  password: string;
  confirmPassword: string;
  phoneNumber: string;
  firstName: string;
  lastName: string;
  countryName: string;
  city: string;
  state: string;
  age: number;
  gender: string;
  title: string;
  bio: string;
  wallet: number;
}
