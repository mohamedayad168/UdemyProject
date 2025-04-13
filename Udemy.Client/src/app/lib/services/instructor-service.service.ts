import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Instructor } from '../models/instructor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InstructorServiceService {
  private apiUrl = `${environment.baseurl}/instructors`;
  private http = inject(HttpClient);
  constructor() {}
  getInstructorById(id: number): Observable<Instructor> {
    return this.http.get<Instructor>(`${this.apiUrl}/${id}`);
  }
  
}
