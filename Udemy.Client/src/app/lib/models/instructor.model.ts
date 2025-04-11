export interface Instructor {
  id?: number;
  name: string;
  title: string;
  bio: string;

  email: string;

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

  totalCourses?: number | null;
  totalReviews?: number | null;
  totalStudents?: number | null;
}

export const dummyInstructor: Instructor = {
  id: 1,
  name: 'John Doe',
  title: 'Senior Instructor',
  bio: 'John Doe is a seasoned instructor with over 10 years of experience in teaching programming languages and software development. He has a passion for educating others and making complex topics accessible to all.',
  totalReviews: 1200,
  totalCourses: 15,
  totalStudents: 5000,
  email: '',

  password: '',
  confirmPassword: '',
  phoneNumber: '',
  firstName: '',
  lastName: '',
  countryName: '',
  city: '',
  state: '',
  age: 0,
  gender: '',
};
