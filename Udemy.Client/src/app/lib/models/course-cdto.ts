import { Instructor } from './instructor.model';
export interface CourseCDTO {
  Title: string;
  Description: string;
  InstructorId: number;
  Language: string;

  CategoryId: number;
  SubcategoryId: number;
  ImageUrl: string;
  VideoUrl: string;
  CourseLevel: string;
  Price: number;
}
