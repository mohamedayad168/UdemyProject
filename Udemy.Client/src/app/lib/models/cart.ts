export type Cart = {
  studentId: number;
  courses: CartCourse[];
};

export type CartCourse = {
  id: number;
  title: string;
  description: string;
  currentPrice: number;
  price: number;
  discount: number;
  imageUrl?: string;
};
