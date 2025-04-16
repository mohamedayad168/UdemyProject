export interface Course {
  id: number;
  title: string;
  description: string;
  status: string;
  courseLevel: string;
  discount?: number;
  price: number;
  duration: number;
  language: string;
  imageUrl?: string | null;
  videoUrl?: string | null;
  noSubscribers: number;
  isFree: boolean;
  isApproved: boolean;
  bestSeller?: string;
  currentPrice: number;
  rating?: number;
  subCategoryId: number;
  categoryId: number;
  instructorName: string;

  instructor: {
    id: number;
    name: string;
  };

  courseGoals: string[];
  courseRequirements: string[];

}
export interface CourseUpdateDTO {
  id: number;
  isDeleted: boolean;
  title: string;
  description: string;
  courseLevel: string;
  discount: number;
  price: number;
  language: string;
  imageUrl: string;
  videoUrl: string;
  subCategoryId: number;
  instructorId: number;
  goals: string;
  requirements: string;
  categoryId?: number;
}
