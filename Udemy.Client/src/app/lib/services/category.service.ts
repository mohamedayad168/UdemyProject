import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Category, SubCategory } from '../models/category.model';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = `${environment.baseurl}/categories`;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
  getPopularCoursesBySubcategory(subcategoryId: number): Observable<Course[]> {
    return this.http.get<Course[]>(`${environment.baseurl}/courses/subcategories/${subcategoryId}/courses`)
      .pipe(
        catchError(error => {
          console.error('Error fetching courses by subcategory:', error);
          return throwError(() => new Error('Error fetching courses by subcategory'));
        })
      );
  }
  
  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}`);
  }
  getCategoriesWithSubcategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}?include=subcategories`);
  }

  getSubcategoriesByCategory(categoryId: number): Observable<SubCategory[]> {
    return this.http.get<SubCategory[]>(`${this.apiUrl}/${categoryId}/subcategories`);
  }
  
  getCoursesByCategory(categoryId: number): Observable<Course[]> {
    // Corrected endpoint to match your API route
    return this.http.get<Course[]>(`${environment.baseurl}/categories/${categoryId}/courses`);
  }
  getCoursesBySubcategory(subcategoryId: number): Observable<Course[]> {
    return this.http.get<Course[]>(`${environment.baseurl}/courses/subcategories/${subcategoryId}/courses`);
  }
  
}


