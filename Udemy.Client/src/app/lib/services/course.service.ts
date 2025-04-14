import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Course } from '../models/course.model';
import { Category } from '../models/category.model';
import { CourseDetail } from '../models/CourseDetail.model';
import { CourseCDTO } from '../models/course-cdto';
import { CourseSearch } from '../models/course-search';
import { CourseParams } from '../models/course-params';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private baseUrl = `${environment.baseurl}/courses`;
  courseSearchLoaded = signal(false);
  coursesWithParameters = signal<CourseSearch[] | null>([]);

  constructor(private http: HttpClient) {}

  getCourseWithParameters(courseParams: CourseParams) {
    let params = new HttpParams();

    params = params.append('pageSize', courseParams.pageSize);
    params = params.append('PageNumber', courseParams.pageNumber);
    params = params.append('SearchTerm', courseParams.searchTerm);

    return this.http
      .get<CourseSearch[]>(this.baseUrl + '/search', {
        params,
      })
      .pipe(
        map((courses) => {
          this.coursesWithParameters.set(courses);

          this.courseSearchLoaded.set(true);
          return courses;
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
}
