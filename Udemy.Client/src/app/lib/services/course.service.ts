import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Course } from '../models/course.model';
import { Category } from '../models/category.model';
import { CourseDetail } from '../models/CourseDetail.model';
import { CourseCDTO } from '../models/course-cdto';
import { CoursePagingResult, CourseSearch } from '../models/course-search';
import { CourseParams } from '../models/course-params';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private baseUrl = `${environment.baseurl}/courses`;
  courseSearchLoaded = signal(false);
  CoursePagingResult = signal<CoursePagingResult | null>(null);
  courseParams = signal<CourseParams>(new CourseParams());

  constructor(private http: HttpClient) {}

  getCourseWithParameters() {
    let params = new HttpParams();

    params = params.append('pageSize', this.courseParams().pageSize);
    params = params.append('PageNumber', this.courseParams().pageNumber);
    params = params.append('SearchTerm', this.courseParams().searchTerm);
    params = params.append('orderBy', this.courseParams().orderBy);

    return this.http
      .get<CoursePagingResult>(this.baseUrl + '/search', {
        params,
      })
      .pipe(
        map((coursePagingResult) => {
          this.CoursePagingResult.set(coursePagingResult);

          this.courseSearchLoaded.set(true);
          return coursePagingResult;
        })
      );
  }

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
      `${environment.baseurl}/categories/${categoryId}/courses`
    );
  }

  createCourse(course: CourseCDTO): Observable<any> {
    console.log(course);
    return this.http.post<any>(`${environment.baseurl}/courses`, course);
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
  
  deleteCourse(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
  }
  updateCourse(courseId: number, course: Course): Observable<Course> {
    return this.http.put<Course>(`${this.baseUrl}/${courseId}`, course);
  }
}  