export interface Instructor {
    id: number;
    name: string;
    bio: string;
    totalReviews?: number;
    totalCourses?: number;
    totalStudents?: number;
}

export const dummyInstructor: Instructor = {
    id: 1,
    name: "John Doe",
    bio: "John Doe is a seasoned instructor with over 10 years of experience in teaching programming languages and software development. He has a passion for educating others and making complex topics accessible to all."
   ,
    totalReviews: 1200,
    totalCourses: 15,
    totalStudents: 5000

  };
