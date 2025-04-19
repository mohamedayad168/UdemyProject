import { Component, inject, input } from '@angular/core';
import { Form, FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { Question, QuestionAnswer, Quiz } from '../../models/quiz';
import { QuizService } from '../../services/quiz.service';
import { CommonModule } from '@angular/common';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-quiz',
  imports: [MatRadioModule, FormsModule,ReactiveFormsModule,CommonModule],
  templateUrl: './quiz.component.html',
  styleUrl: './quiz.component.css'
})
export class QuizComponent {
  answers!:Array<string>;
  seasons: string[] = ['Winter', 'Spring', 'Summer', 'Autumn'];

  quiz!:Quiz;
  courseId=input<number>();
  quizService=inject(QuizService);
  quizForm!:any;
  private courseID!: number;
  studentGrade:any=null;
  //flags
  showExamScreen=false;
  showStartScreen=false;
  showStudentGrade=false;
  quizWithAnswers: any;
  showQuizAnswers=false;



  /**
   *
   */
  constructor(private quizFormGroup:FormBuilder) {

  }

  ngOnInit() {
    const courseId = this.courseId();
    if (courseId === undefined) {
      this.showStartScreen = false;
      console.error('Course ID is undefined.');
      return;
    }
    this.courseID=courseId;

    this.quizService.getStudentGrade(this.courseID)
    .pipe(
      catchError(err => {
        if (err.status === 404) {
          console.log('Not Found (404)');
          this.showExamScreen=true;
          this.showStartScreen=false;
          this.studentGrade=null;
          // Do something, like show a message or fallback
        }
        return of(null); // Return a fallback value or empty observable
      })
    )
    .subscribe((data: any) => {
      if (data) {
        console.log('student grade received', data);
        this.showStudentGrade=true;
        this.studentGrade=data;
      }
      else{
        this.showStartScreen=false;
      }
    });

  }


  startQuiz() {
  this.showStartScreen = true;
  const courseId = this.courseId();
  if (courseId === undefined) {
    this.showStartScreen = false;

    console.error('Course ID is undefined.');
    return;
  }
  this.courseID=courseId;
  this.quizService.getCourseQuiz(courseId).subscribe((data: Quiz) => {
    if (data) {
      console.log('quiz data data received', data);
      this.quiz = data;
      // this.answers = new Array(data.questions.length).fill('');
      // let answerObject=this.quiz.questions.map((question, index) => ({ [question.id]: '' }));
      // // console.log(`answer object ${JSON.stringify(answerObject)} f
      // // flattented: ${JSON.stringify(Object.assign({}, ...answerObject) ) }`);
      const formControls: { [key: string]: any } = {};
      this.quiz.questions.forEach((question) => {
        formControls[question.id] = ['',Validators.required];
      })
      console.log('form controls', formControls);

      this.quizForm = this.quizFormGroup.group(formControls);
    }
  });



}
submitted=false;
submitAnswers() {
  this.submitted = true;
  console.log('submitting answers', this.quizForm);
  if(this.quizForm.invalid) return;
  console.log('form is valid answers is :', this.quizForm.value);

  const questionAnswers:QuestionAnswer[]=this.quiz.questions.map((question, index) => ({ quizId: this.quiz.id, questionId:question.id, answer: this.quizForm.value[question.id] }));
  this.quizService.postQuizAnswersForEvaluation(questionAnswers,this.courseID,this.quiz.id).subscribe((data: any) => {
      if(data) {
        console.log('student grade received', data);
        this.studentGrade=data;
        this.showExamScreen=false;
      }
  })



}

loadAnswers() {

  this.quizService.getQuizWithAnswers(this.courseID).subscribe((data: any) => {
    if(data){
      console.log('quiz with answers received', data);
      this.showExamScreen=false;
  this.showStartScreen=false;
  this.showStudentGrade=true;
  this.showQuizAnswers=true;
      this.quizWithAnswers=data;
    }
  })

}



isFormInvalid() {

  if(this.answers==undefined) return true;
  for (let i = 0; i < this.answers.length; i++) {
    if (this.answers[i] === '') {
      console.log('form is invalid');

      return true;
    }
  }
  console.log('form is valid answers is :', this.answers);

  return false;
}

getAnswerValue(choice: string,question: Question): string {


    if(question.type=='Multiple Choice')
      {
        if(choice==question.choiceA) return 'A';
        if(choice==question.choiceB) return 'B';
        if(choice==question.choiceC) return 'C';
      }
      return choice;
}
}
