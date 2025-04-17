import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Section } from '../models/CourseDetail.model';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  private apiUrl = `${environment.baseurl}/Section`;  

  constructor(private http: HttpClient) {}

  // Fetch sections for a specific course
  getSections(courseId: number): Observable<Section[]> {
    return this.http.get<Section[]>(`${this.apiUrl}?courseId=${courseId}`);
  }

  getSectionsByCourseId(courseId: number): Observable<Section[]> {
    const params = { trackChanges: false };
    return this.http.get<Section[]>(`${this.apiUrl}/course/${courseId}`, { params });
  }
  createSection(section: Section): Observable<any> {
    return this.http.post(`${this.apiUrl}`, section);
  }
 
  updateSection(id: number, section: Section): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/${id}`, section, { responseType: 'text' as 'json' });
  }
  
  
  deleteSection(sectionId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${sectionId}`);
  }

  }

