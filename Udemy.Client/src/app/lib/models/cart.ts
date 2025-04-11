export type Cart = {
  studentId: number;
  paymentIntentId?: string;
  clientSecret?: string;
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
