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
  private apiUrl = `${environment.baseurl}/instructors`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Instructor[]> {
    return this.http.get<Instructor[]>(this.apiUrl);
  }

  getInstructorById(id: number): Observable<Instructor> {
    return this.http.get<Instructor>(`${this.apiUrl}/${id}`);
  }

  getInstructorByTitle(title: string): Observable<Instructor> {
    return this.http.get<Instructor>(`${this.apiUrl}/title/${title}`);
  }

  create(instructor: Instructor): Observable<Instructor> {
    return this.http.post<Instructor>(`${this.apiUrl}/create`, instructor);
  }

  update(id: number, instructor: Instructor): Observable<Instructor> {
    return this.http.put<Instructor>(`${this.apiUrl}/${id}`, instructor);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  saveInstructorProfile(profileData: any): Observable<Instructor> {
    return this.http.post<Instructor>(`${this.apiUrl}/create`, profileData);
  }

  saveSocialMediaLinks(links: SocialMediaLink[]): Observable<any> {
    return this.http.post(
      `${environment.baseurl}/api/SocialMedia/create`,
      links
    );
  }

  getInstructorDetails(instructorId: number): Observable<Instructor> {
    return this.http.get<Instructor>(
      `${this.apiUrl}/details?instructorId=${instructorId}`
    );
  }

  getInstructorCourses(instructorId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${instructorId}/courses`);
  }
}
