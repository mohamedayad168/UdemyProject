import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AccountService } from './account.service';
import { Observable } from 'rxjs';
import { PostReview } from '../models/review';

@Injectable({ providedIn: 'root' })
export class UserService {

  private apiUrl = `${environment.baseurl}`;
  httpclient=inject(HttpClient);
  getMyLearning():Observable<any>{
    return this.httpclient.get<any>(`${this.apiUrl}/students/my-learnings`);
  }
  postReview(reviewModel: PostReview): Observable<PostReview> {
    console.log('reviewModel from service', reviewModel);
    console.log(`Posting to ${this.apiUrl}/Enrollments/ratings/${reviewModel.courseId}`);
    return this.httpclient.post<PostReview>(`${this.apiUrl}/Enrollments/ratings/${reviewModel.courseId}`, reviewModel);
  }

  getCourseRating(courseId: number): Observable<PostReview>
  {
    console.log('reviewModel from service', courseId);
    console.log(`getting from ${this.apiUrl}/Enrollments/ratings/${courseId}`);
    return this.httpclient.get<PostReview>(`${this.apiUrl}/Enrollments/ratings/${courseId}`);
  }

  getEnrollement(studentId: number,courseId: number):Observable<any>{
    console.log(`getting from ${this.apiUrl}/enrollments/student/${studentId}/course/${courseId}`);
    return this.httpclient.get<any>(`${this.apiUrl}/enrollments/student/${studentId}/course/${courseId}`);
  }

}
