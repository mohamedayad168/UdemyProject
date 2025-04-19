import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Lesson } from '../models/CourseDetail.model';
import { LessonCDto } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class LessonService {

  private apiUrl = `${environment.baseurl}/Lesson`; 

  constructor(private http: HttpClient) {}

  
  getLessons(sectionId: number): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(`${this.apiUrl}`);
  }
  getLessonById(id: number): Observable<Lesson> {
    return this.http.get<Lesson>(`${this.apiUrl}/${id}`);
  }
  createLesson(lesson: LessonCDto): Observable<any> {
    console.log('Lesson to be created:', lesson);  
    return this.http.post(`${this.apiUrl}`, lesson);
}
  updateLesson(id: number, lesson: Lesson): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, lesson);
  }
  deleteLesson(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  uploadVideo(lessonId: number, formData: FormData): Observable<any> {
    return this.http.post<any>(`https://your-api-url/api/Lessons/${lessonId}/upload-video`, formData);
  }
  getLessonsBySectionId(sectionId: number, trackChanges: boolean = false): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(`${this.apiUrl}/section/${sectionId}?trackChanges=${trackChanges}`);
  }

}
