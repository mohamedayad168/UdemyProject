import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CourseRating, rating } from '../models/review';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewServiceService {

  httpClient: HttpClient;

  private apiUrl = `${environment.baseurl}/Enrollments/ratings`;

  constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;
   }

  getCourseRatings(courseId: number): Observable<any> {
    return this.httpClient.get<any>(`${this.apiUrl}/${courseId}`);
  }

}
