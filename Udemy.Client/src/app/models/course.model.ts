export interface Course {
    id: number;
    title: string;
    description: string;
    rating: number;
    currentPrice: number;
    imageUrl: string;
    instructor: {
      id: number;
      name: string;
    };
    subCategory: {
      id: number;
      name: string;
    };
    bestSeller: boolean;
  }
 