export interface ICourse {
    id: string;
    title: string;
    description: string;
    price: number;
    previewImageLink: string;
    status: 'Archived' | 'Published';
    imageUrl: string;
    categories: { id: number; name: string }[];
    category: string;
    imageLinks: string[];
    location: any;
    createdDate: Date;
    modifiedDate: null;
    isDeleted: boolean;
    courseLevel: string;
    discount: number;
    duration: number;
    language: string;
    videoUrl: string;
    noSubscribers: number;
    isFree: boolean;
    isApproved: boolean;
    currentPrice: number;
    rating: number;
    subCategoryId: number;
    categoryId: number;
    instructorId: number;
    instructorName: null;
  }
  
  export interface ICourseCDTO {
    title: string;
    description: string;
    status: string;
    courseLevel: string;
    price: number;
    currentPrice: number;
    language: string;
    image?: File | string;
    videoUrl?: string;
    isFree: boolean;
    isApproved: boolean;
    isDeleted: boolean;
    subCategoryId: number;
    instructorId: number;
    rating: number;
    noSubscribers: number;
    createdDate: string; // ISO string format
    discount: number;
  }
  