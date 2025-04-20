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
import { ActivatedRoute, RouterModule } from '@angular/router';

import { Question, QuestionType, Quiz } from '../../lib/models/quiz';

@Component({
  selector: 'app-quiz-management',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
  templateUrl: './instructor-add-exam.component.html',
  styleUrls: ['./instructor-add-exam.component.css'],
})
export class InstructorAddExamComponent implements OnInit {
  courseId: number = 0;
  quizzes: Quiz[] = [];
  newQuiz: Quiz = {
    id: 0,
    courseId: this.courseId,
    questions: [],
  };
  nextQuizId: number = 1;
  nextQuestionId: number = 1;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Extract courseId from route parameters
    this.route.paramMap.subscribe((params) => {
      const courseId = params.get('courseId');
      this.courseId = courseId ? +courseId : 0;
      this.newQuiz.courseId = this.courseId;
      // In a real app, fetch existing quizzes for the course
      // this.quizzes = this.quizService.getQuizzesByCourseId(this.courseId);
    });
  }

  addQuestion(): void {
    const newQuestion: Question = {
      id: this.nextQuestionId++,
      quizId: this.newQuiz.id || this.nextQuizId, // Use nextQuizId if newQuiz.id is not set
      type: 'Multiple Choice',
      questionTxt: '',
      choiceA: '',
      choiceB: '',
      choiceC: '',
      answer: '', // Initialize answer as empty
    };
    this.newQuiz.questions.push(newQuestion);
  }

  removeQuestion(index: number): void {
    this.newQuiz.questions.splice(index, 1);
  }

  onQuestionTypeChange(question: Question): void {
    // Reset answer when question type changes to prevent invalid answers
    question.answer = '';
    // Reset choices for True or False questions
    if (question.type === 'True or False') {
      question.choiceA = null;
      question.choiceB = null;
      question.choiceC = null;
    } else {
      question.choiceA = question.choiceA || '';
      question.choiceB = question.choiceB || '';
      question.choiceC = question.choiceC || '';
    }
  }

  addQuiz(): void {
    if (this.newQuiz.questions.length > 0) {
      const quizToAdd: Quiz = {
        ...this.newQuiz,
        id: this.nextQuizId++, // Auto-generate quizId
        courseId: this.courseId,
        questions: this.newQuiz.questions.map((q) => ({
          ...q,
          quizId: this.nextQuizId - 1, // Ensure question quizId matches the new quiz
        })),
      };
      this.quizzes.push(quizToAdd);
      // In a real app, save to backend
      // this.quizService.addQuiz(quizToAdd);

      // Reset form
      this.newQuiz = {
        id: 0,
        courseId: this.courseId,
        questions: [],
      };
      this.nextQuestionId = 1;
    }
  }

  removeQuiz(quizId: number): void {
    this.quizzes = this.quizzes.filter((quiz) => quiz.id !== quizId);
    // In a real app, delete from backend
    // this.quizService.deleteQuiz(quizId);
  }
}
