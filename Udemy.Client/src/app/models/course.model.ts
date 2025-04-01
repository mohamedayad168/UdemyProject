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
  imageUrl?: string;
  videoUrl?: string;
  noSubscribers: number;
  isFree: boolean;
  isApproved: boolean;
  bestSeller?: string;
  currentPrice: number;
  rating?: number;
  subCategory: {
    id: number;
    name: string;
  };
  instructor: {
    id: number;
    name: string;
  };
}
