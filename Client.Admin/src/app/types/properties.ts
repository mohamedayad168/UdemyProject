export interface IProperty {
  id: number;
  title: string;
  description: string;
  price: number;
  previewImageLink: string;
  status: string;
  categories: { id: number; name: string }[];
  imageLinks: string[];
  location: any;
}
