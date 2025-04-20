import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';
import {
  QuestionAnswer,
  Quiz,
  QuizAnswersForSubmit,
  QuizDTO,
} from '../models/quiz';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class QuizService {
  private readonly _httpClient: HttpClient;
  private readonly _baseUrl = `${environment.baseurl}/Quiz`;
  constructor(httpClient: HttpClient, private authService: AccountService) {
    this._httpClient = httpClient;
  }

  getCourseQuiz(courseId: number): Observable<Quiz> {
    return this._httpClient.get<Quiz>(`${this._baseUrl}/${courseId}`);
  }

  //PostQuizAnswersForEvaluation
  postQuizAnswersForEvaluation(
    questionAnswers: QuestionAnswer[],
    courseId: number,
    quizId: number
  ): Observable<any> {
    const userId = this.authService.currentUser()?.id;
    if (!userId) throw new Error('User is not logged in');
    const quizForSubmit: QuizAnswersForSubmit = {
      quizId: quizId,
      courseId: courseId,
      studentId: userId,
      answers: questionAnswers,
    };
    const postUrl = `${this._baseUrl}/Evaluate/${quizId}`;
    console.log(
      `Posting quiz Answers ${JSON.stringify(quizForSubmit)} to ${postUrl} `
    );
    return this._httpClient.post<any>(postUrl, quizForSubmit);
  }

  getStudentGrade(courseId: number): Observable<any> {
    const userId = this.authService.currentUser()?.id;
    if (!userId) throw new Error('User is not logged in');
    const getGradeUrl = `${this._baseUrl}/${courseId}/StudentGrade/${userId}`;
    console.log(`Getting student grade from ${getGradeUrl}`);
    return this._httpClient.get<any>(getGradeUrl);
  }

  getQuizWithAnswers(courseId: number) {
    const userId = this.authService.currentUser()?.id;
    if (!userId) throw new Error('User is not logged in');
    const getAnswersUrl = `${this._baseUrl}/${courseId}/Answers`;
    console.log(`Getting Answers from ${getAnswersUrl}`);
    return this._httpClient.get<any>(getAnswersUrl);
  }
  private quizzes: QuizDTO[] = [
    {
      id: 1,
      courseId: 1,

      questions: [],
    },
    {
      id: 2,
      courseId: 2,

      questions: [],
    },
  ];

  getQuizzesByCourse(courseId: number): Observable<Quiz[]> {
    return this._httpClient.get<Quiz[]>(`${this._baseUrl}/${courseId}`);
  }

  getAllQuizzes(): Observable<QuizDTO[]> {
    return of(this.quizzes);
  }

  createQuiz(quiz: QuizDTO): Observable<QuizDTO> {
    const newQuiz = { ...quiz, id: this.quizzes.length + 1 };
    this.quizzes.push(newQuiz);
    return of(newQuiz);
  }

  updateQuiz(quiz: QuizDTO): Observable<QuizDTO> {
    const index = this.quizzes.findIndex((q) => q.id === quiz.id);
    if (index !== -1) {
      this.quizzes[index] = quiz;
    }
    return of(quiz);
  }
}
