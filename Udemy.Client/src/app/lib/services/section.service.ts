import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Section } from '../models/CourseDetail.model';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  private apiUrl = `${environment.baseurl}/sections`;  

  constructor(private http: HttpClient) {}

  // Fetch sections for a specific course
  getSections(courseId: number): Observable<Section[]> {
    return this.http.get<Section[]>(`${this.apiUrl}?courseId=${courseId}`);
  }

  getSectionById(sectionId: number): Observable<Section> {
    return this.http.get<Section>(`${this.apiUrl}/${sectionId}`);
  }
  createSection(section: Section): Observable<any> {
    return this.http.post(`${this.apiUrl}`, section);
  }
  updateSection(sectionId: number, section: Section): Observable<any> {
    return this.http.put(`${this.apiUrl}/${sectionId}`, section);
  }
  deleteSection(sectionId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${sectionId}`);
  }
  getSectionsByCourseId(courseId: number): Observable<Section[]> {
    return this.http.get<Section[]>(`${this.apiUrl}/ByCourse/${courseId}`);
  }
}
