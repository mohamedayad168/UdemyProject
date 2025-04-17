import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Answer, Ask, CreateAsk,CreateAnswerModel } from '../../models/ask';
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

  updateAsk(courseId: number, ask: CreateAsk, askId: number): Observable<void> {
    console.log(`sending put request to ${this.baseUrl}/asks`);
    const userId = this.authService.currentUser()?.id;
    return this.httpClient.put<void>(`${environment.baseurl}/users/${userId}/courses/${courseId}/asks/${askId}`, ask);
  }
  deleteAsk(courseId: number, askId: number) {
    console.log(`sending delete request to ${this.baseUrl}/asks`);
    const userId = this.authService.currentUser()?.id;
    return this.httpClient.delete<void>(`${environment.baseurl}/users/${userId}/courses/${courseId}/asks/${askId}`);
  }

  getQuestionReplys(courseId: number,questionId: number): Observable<Array<Answer>> {
    console.log(`sending get request to ${this.baseUrl}/${courseId}/asks/${questionId}/answers`);

    return this.httpClient.get<Array<Answer>>(`${this.baseUrl}/${courseId}/asks/${questionId}/answers`);

  }
  createAnswer(courseId: number, askId: number, replyContent: string): Observable<Answer> {
    console.log(`sending answer post request to ${this.baseUrl}/asks/${askId}/answers`);
    const userId = this.authService.currentUser()?.id;
    let answerModel:CreateAnswerModel={content: replyContent};
    return this.httpClient.post<Answer>(`${environment.baseurl}/users/${userId}/courses/${courseId}/asks/${askId}/answer`, answerModel);
  }
  getUserQuestions(courseId: number, pageNumber: number=1, pageSize: number=5): Observable<Array<Ask>> {
    console.log(`getting user questions from ${this.baseUrl}/users/${this.authService.currentUser()?.id}/courses/${courseId}/asks`);
    return this.httpClient.get<Array<Ask>>(`${environment.baseurl}/users/${this.authService.currentUser()?.id}/courses/${courseId}/asks?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }


}
