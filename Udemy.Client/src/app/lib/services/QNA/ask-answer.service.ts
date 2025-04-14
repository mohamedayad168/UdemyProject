import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Ask, CreateAsk } from '../../models/ask';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { AccountService } from '../account.service';

@Injectable({
  providedIn: 'root'
})
export class AskAnswerService {

  private readonly baseUrl = `${environment.baseurl}/Courses`;

  httpClient: HttpClient=inject(HttpClient);
  authService = inject(AccountService);
  getCourseQnA(courseId: number, pageNumber: number=1, pageSize: number=5): Observable<Array<Ask>> {
    console.log(`sending get request to ${this.baseUrl}/${courseId}/asks?PageNumber=${pageNumber}&PageSize=${pageSize}`);

    return this.httpClient.get<Array<Ask>>(`${this.baseUrl}/${courseId}/asks?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }

  createAsk(courseId: number, ask: CreateAsk): Observable<CreateAsk> {
    console.log(`sending post request to ${this.baseUrl}/asks`);
    const userId = this.authService.currentUser()?.id;
    return this.httpClient.post<CreateAsk>(`${environment.baseurl}/users/${userId}/courses/${courseId}/asks`, ask);
  }

}
