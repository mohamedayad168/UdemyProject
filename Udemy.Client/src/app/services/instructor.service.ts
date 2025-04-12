// src/app/services/instructor.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Instructor } from '../lib/models/instructor.model';
import { Observable } from 'rxjs';
import { SocialMediaLink } from '../lib/models/SocialMedia.model';

@Injectable({
  providedIn: 'root',
})
export class InstructorService {
  private apiUrl = `${environment.baseurl}`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Instructor[]> {
    return this.http.get<Instructor[]>(this.apiUrl);
  }

  create(instructor: Instructor): Observable<Instructor> {
    return this.http.post<Instructor>(this.apiUrl, instructor);
  }

  update(id: number, instructor: Instructor): Observable<Instructor> {
    return this.http.put<Instructor>(`${this.apiUrl}/${id}`, instructor);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  saveInstructorProfile(profileData: any): Observable<Instructor> {
    return this.http.post<Instructor>(
      `${this.apiUrl}/instructors/create`,
      profileData
    );
  }
  saveSocialMediaLinks(links: SocialMediaLink[]): Observable<any> {
    return this.http.post(`${this.apiUrl}/SocialMedia/create`, links);
  }
}
