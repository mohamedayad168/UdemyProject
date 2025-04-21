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

export interface LessonCDto {
  articleContent: string;
  title: string;
  videoUrl: File;
  duration: number;
  isDeleted: false;
  type: string;

  sectionId: number;
}

export interface SectionCDTO {
  id?: number;
  title: string;
  courseId: number;
  noLessons: number;
  lessons: LessonCDto[];
}
export interface LessonUDto {
  id: number; // لازم للتمييز عند التحديث
  title: string;
  videoUrl: string;
  sectionId: number;
  articleContent?: string;
  type?: string;
  duration?: number;
  isDeleted?: boolean;
}
export interface SectionUDTO {
  id: number;
  title: string;
  duration: number;
  noLessons: number;
  courseId: number;
}
