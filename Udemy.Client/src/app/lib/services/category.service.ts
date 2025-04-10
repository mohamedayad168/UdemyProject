import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { Category, SubCategory } from '../models/category.model';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = `${environment.baseurl}/categories`;

  constructor(private http: HttpClient) {}

  getCategories(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
  getCategoriesWithSubcategories(): Observable<Category[]> {
    return this.http.get<Category[]>(
      `${this.apiUrl}/categories?include=subcategories`
    );
  }
  getPopularCoursesBySubcategory(subcategoryId: number): Observable<Course[]> {
    return this.http.get<Course[]>(
      `${this.apiUrl}/subcategories/${subcategoryId}/courses?sort=popularity&limit=5`
    );
  }
  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}`);
  }
  getSubcategoriesByCategory(categoryId: number): Observable<SubCategory[]> {
    return this.http.get<SubCategory[]>(
      `${this.apiUrl}/categories/${categoryId}/subcategories`
    );
  }
}
