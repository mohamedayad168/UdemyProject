export interface SubCategory {
    id: number;
    name: string;
  }
  
  export interface Category {
    id: number;
    name: string;
    learners: string;
    subcategories: SubCategory[];
  }
  