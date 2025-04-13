export type CourseSearch = {
  id: number;
  title: string;
  description: string;
  instructorName: string;
  rating: number;
  duration: number;
  courseLevel: string;
  imageUrl?: string;
  price: number;
  goals: string[];
};
