import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Course } from '../models/course.model';
import { Category } from '../models/category.model';
import { CourseDetail } from '../models/CourseDetail.model';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  // private apiUrl = `${environment.baseurl}/courses`;

  constructor(private http: HttpClient) {}

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(
      environment.baseurl + '/Courses/page?PageSize=50&PageNumber=1'
      // environment.baseurl + '/Courses'
    );
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.baseurl}/categories`);
  }


  getCoursesByCategory(categoryId: number): Observable<Course[]> {
    return this.http.get<Course[]>(
      `${environment.baseurl}/courses/category/${categoryId}`
    );
  }



  getCourseById(
    id: number,
    detailed: boolean = false
  ): Observable<CourseDetail> {
    console.log(
      `Fetching course details for ID: ${id} with detailed=${detailed}`
    );

    return this.http.get<CourseDetail>(
      `${environment.baseurl}/Courses/${id}?detailed=${detailed}`
    );
  }
}
