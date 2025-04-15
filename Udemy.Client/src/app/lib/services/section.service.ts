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

  
}
