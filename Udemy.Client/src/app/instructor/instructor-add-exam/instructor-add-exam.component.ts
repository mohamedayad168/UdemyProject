import { QuizService } from './../../lib/services/quiz.service';
import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  FormsModule,
  NgForm,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

import {
  Question,
  QuestionType,
  Quiz,
  QuizCDTO,
  QuizQuestionCDTO,
} from '../../lib/models/quiz';
import { HttpClient } from '@angular/common/http';
import { AccountService } from '../../lib/services/account.service';

@Component({
  selector: 'app-quiz-management',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './instructor-add-exam.component.html',
  styleUrls: ['./instructor-add-exam.component.css'],
})
export class InstructorAddExamComponent implements OnInit {
  courseId: number = 0;
  quizzes: Quiz[][] = [];
  newQuiz: QuizCDTO = {
    CourseId: this.courseId,
    QuizQuestions: [],
  };

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private quizService: QuizService,
    private router: Router,
    private accountService:AccountService
  ) {}
intructorId :number|undefined
  ngOnInit(): void {
    // Extract courseId from route parameters
    this.route.paramMap.subscribe((params) => {
      const courseId = params.get('courseId');
      this.courseId = courseId ? +courseId : 0;
      this.newQuiz.CourseId = this.courseId;
      this.fetchQuizzes();
      this.intructorId = this.accountService.currentUser()?.id
    });
  }

  fetchQuizzes(): void {
    // Fetch quizzes for the courseId
    this.quizService.getQuizzesByCourse(this.courseId).subscribe({
      next: (response) => {
        this.quizzes = response ? [response] : [];
      },
      error: (error) => {
        console.error('Error fetching quizzes:', error);
        ('Failed to load quiz. Please try again.');
        this.quizzes = [];
      },
    });
  }

  addQuestion(): void {
    const newQuestion: QuizQuestionCDTO = {
      Type: 'Multiple Choice',
      QuestionTxt: '',
      ChoiceA: '',
      ChoiceB: '',
      ChoiceC: '',
      AnswerTxt: '',
    };
    this.newQuiz.QuizQuestions.push(newQuestion);
  }

  removeQuestion(index: number): void {
    this.newQuiz.QuizQuestions.splice(index, 1);
  }

  onQuestionTypeChange(question: QuizQuestionCDTO): void {
    // Reset answer and choices when question type changes
    question.AnswerTxt = '';
    if (question.Type === 'True or False') {
      question.ChoiceA = null;
      question.ChoiceB = null;
      question.ChoiceC = null;
    } else {
      question.ChoiceA = question.ChoiceA || '';
      question.ChoiceB = question.ChoiceB || '';
      question.ChoiceC = question.ChoiceC || '';
    }
  }

  addQuiz(): void {
    if (this.newQuiz.QuizQuestions.length > 0) {
      // Send QuizCDTO to backend
      this.quizService.createQuizByCourseId(this.newQuiz).subscribe({
        next: (createdQuiz) => {
          this.quizzes.push(createdQuiz);
          // Reset form
          this.newQuiz = {
            CourseId: this.courseId,
            QuizQuestions: [],
          };
          this.router.navigate([`instructors/${this.intructorId}/courses`])
        },
        error: (error) => {
          console.error('Error creating quiz:', error);
        },
      });
    }
  }

  // removeQuiz(quizId: number): void {
  //   this.http.delete(`/api/quizzes/${quizId}`).subscribe({
  //     next: () => {
  //       this.quizzes = this.quizzes.filter((quiz) => quiz.id !== quizId);
  //     },
  //     error: (error) => {
  //       console.error('Error deleting quiz:', error);
  //     },
  //   });
  // }
}
