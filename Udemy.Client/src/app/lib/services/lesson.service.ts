import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Lesson } from '../models/CourseDetail.model';

@Injectable({
  providedIn: 'root'
})
export class LessonService {

  private apiUrl = `${environment.baseurl}/lessons`; 

  constructor(private http: HttpClient) {}

  
  getLessons(sectionId: number): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(`${this.apiUrl}?sectionId=${sectionId}`);
  }
  getLessonById(id: number): Observable<Lesson> {
    return this.http.get<Lesson>(`${this.apiUrl}/${id}`);
  }
  createLesson(lesson: Lesson): Observable<any> {
    return this.http.post(`${this.apiUrl}`, lesson);
  }
  updateLesson(id: number, lesson: Lesson): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, lesson);
  }
  deleteLesson(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  
}
