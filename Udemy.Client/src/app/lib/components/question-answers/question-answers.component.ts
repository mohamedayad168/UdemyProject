import {CommonModule} from '@angular/common';
import {Component, inject, input} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {Answer, Ask} from '../../models/ask';
import {AskAnswerService} from '../../services/QNA/ask-answer.service';

@Component({
  selector: 'app-question-answers',
  imports: [CommonModule, FormsModule],
  templateUrl: './question-answers.component.html',
  styleUrl: './question-answers.component.css'
})
export class QuestionAnswersComponent {
  askService: AskAnswerService = inject(AskAnswerService);
  courseId = input<number>();
  question = input<Ask>();
  intervel!: any;
  ngOnInit() {
    const courseId = this.courseId();
    let question = this.question();
    if (courseId === undefined || question === undefined) {
      console.error('Course ID or question ID is undefined.');
      return;
    }
    this.askService.getQuestionReplys(courseId, question.id)
        .subscribe((data: Array<Answer>) => {
          console.log('Questions received', data);
          if (data) {
            question.answers = data;
            console.log(`question: ${JSON.stringify(question)}`);
          }
        });

        this.intervel = setInterval(() => {
          this.loadNewReplies();
        }, 5000);

  }

  ngOnDestroy() {
    clearInterval(this.intervel);
  }

  loadNewReplies() {
    const courseId = this.courseId();
    let question = this.question();
    if (courseId === undefined || question === undefined) {
      console.error('Course ID or question ID is undefined.');
      return;
    }
    this.askService.getQuestionReplys(courseId, question.id)
        .subscribe((data: Array<Answer>) => {
          console.log('Questions received', data);
          if (data) {
            question.answers = data;
            console.log(`question: ${JSON.stringify(question)}`);
          }
        });
  }

  get questionWithAnswers() {
    return this.question();
  }

  replyContent = '';
  submitReply() {
    console.log(`replyContent: ${this.replyContent}`);

    const courseId = this.courseId();
    let question = this.question();
    if (courseId === undefined || question === undefined) {
      console.error('Course ID or question ID is undefined.');
      return;
    }
    this.askService.createAnswer(courseId, question.id, this.replyContent)
        .subscribe(
            (data) => {
              console.log('Answer Posted to server', data);
              this.replyContent = '';
              if(data) this.loadNewReplies();
            })
  }
}
