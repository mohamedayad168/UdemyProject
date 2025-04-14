export interface Instructor {
  id?: number;
  name?: string;
  Title: string;
  bio: string;
  UserName: string;
  Email: string;

  Password: string;
  ConfirmPassword: string;

  PhoneNumber: string;

  FirstName: string;

  LastName: string;

  CountryName: string;

  City: string;

  State: string;

  Age: number;

  Gender: string;

  totalCourses?: number | null;
  totalReviews?: number | null;
  totalStudents?: number | null;
}

export const dummyInstructor: Instructor = {
  id: 1,
  name: 'John Doe',
  Title: 'Senior Instructor',
  bio: 'John Doe is a seasoned instructor with over 10 years of experience in teaching programming languages and software development. He has a passion for educating others and making complex topics accessible to all.',
  totalReviews: 1200,
  totalCourses: 15,
  totalStudents: 5000,
  Email: '',
  UserName: 'join',
  Password: '',
  ConfirmPassword: '',
  PhoneNumber: '',
  FirstName: '',
  LastName: '',
  CountryName: '',
  City: '',
  State: '',
  Age: 0,
  Gender: '',
};
