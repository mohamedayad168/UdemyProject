import { Component, inject, input, signal, TemplateRef } from '@angular/core';
import { ButtonDirective, CardBodyComponent, CardComponent, CollapseDirective } from '@coreui/angular';
import { ReadMoreComponent } from "../read-more/read-more.component";
import { FormsModule } from '@angular/forms';
import { Ask, CreateAsk, UpdateAsk } from '../../models/ask';
import { AskAnswerService } from '../../services/QNA/ask-answer.service';
import { CommonModule } from '@angular/common';
import { Toast } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Dialog } from 'primeng/dialog';
import { Button, ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { QuestionAnswersComponent } from "../question-answers/question-answers.component";
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AccountService } from '../../services/account.service';



@Component({
  selector: 'app-qna',
  imports: [ReadMoreComponent, FormsModule, CommonModule, Toast, Dialog, Button, QuestionAnswersComponent,MatSlideToggleModule],
  templateUrl: './qna.component.html',
  styleUrl: './qna.component.css',
  providers: [MessageService]
})
export class QNAComponent {


  createAskModel:CreateAsk={title:'',content:''};
  updateAskModel!:UpdateAsk;
  askService:AskAnswerService=inject(AskAnswerService);
  courseQuestions!:Array<Ask>;
  courseId=input<number>();
  pollingInterval!: any;
  pageNumber=1;
  pageSize=5;
  isLastPage=false;
  filterUserQuestions: boolean = false;
  authService = inject(AccountService);



  constructor(private messageService: MessageService) {}

  ngOnInit() {
    this.loadData();
    // this.pollingInterval = setInterval(() => {
    //   this.loadData(); // method to call your service and update the view
    // }, 5000);

  }

  // ngOnDestroy() {
  //   clearInterval(this.pollingInterval);
  // }

  isUserQuestion(question: Ask) {
    return (question.userId==this.authService.currentUser()?.id) ;
  }

  loadData() {
    this.isLastPage=false;
    this.pageNumber=1;
    const courseId=this.courseId();
    if(courseId==undefined) return;
    if(this.filterUserQuestions){
      this.askService.getUserQuestions(courseId).subscribe((data) => {
        console.log('Questions received', data);
        if (data) {
          this.courseQuestions = data;
          this.pageNumber++;
        }
      })
      return;
    }
    this.askService.getCourseQnA(courseId).subscribe((data) => {
      console.log('Questions received', data);
      if (data) {
        this.courseQuestions = data;
        this.pageNumber++;
      }

    })
}

loadMoreQuestions() {
  const courseId=this.courseId();
  if(courseId==undefined) return;
  if(this.filterUserQuestions) {
    this.askService.getUserQuestions(courseId,this.pageNumber).subscribe((data) => {
      console.log('Questions received', data);
      if (data) {
        this.courseQuestions.push(...data);
        this.pageNumber++;
      }
      if(data.length<this.pageSize) this.isLastPage=true;
    })
    return;
  }
  this.askService.getCourseQnA(courseId,this.pageNumber,this.pageSize).subscribe((data:Array<Ask>) => {
    console.log('Questions received', data);
    if (data) {
      this.courseQuestions.push(...data);
      this.pageNumber++;
    }
    if(data.length<this.pageSize) this.isLastPage=true;
  })
}

toggleFilterQuestions() {
  console.log("toggling filter",this.filterUserQuestions);
  this.filterUserQuestions = !this.filterUserQuestions;
  //TODO: implement
  if(this.filterUserQuestions){
  console.log("toggling filter",this.filterUserQuestions);
    console.log("filtering user questions");
    this.pageNumber=1;
    this.askService.getUserQuestions(this.courseId()!,this.pageNumber,this.pageSize).subscribe((data) => {
      console.log('Questions received', data);
      if (data) {
        this.courseQuestions = data;
        this.pageNumber++;
      }
    })
  }
  else{
    console.log("getting all questions");

    this.loadData();

  }

  }


submitReview() {
  console.log(`askModel: ${JSON.stringify(this.createAskModel)}`);

  this.askService.createAsk(this.courseId()!, this.createAskModel).subscribe((data) => {
    console.log('Question Posted to server', data);
    this.loadData();
    this.createAskModel={title:'',content:''};
    this.showSuccess();
    this.closeModal();

  });

}
submitEditReview() {
  if(!this.updateAskModel || this.updateAskModel.id===0) return;
  console.log(`askModel: ${JSON.stringify(this.updateAskModel)}`);
  const model={
    title:this.updateAskModel.title,
    content:this.updateAskModel.content
  }
  this.askService.updateAsk(this.courseId()!, model,this.updateAskModel.id).subscribe((data) => {
    console.log('Question updated to server', data);
    this.loadData();
    this.updateAskModel={id:0,title:'',content:''};
    this.showSuccess();
    this.closeModal();

  });
}

deleteQuestion(question: Ask) {
  console.log(`delteing question: ${JSON.stringify(question)}`);
  this.askService.deleteAsk(this.courseId()!, question.id).subscribe((data) => {
    console.log('Question deleted to server', data);
    this.loadData();
    this.showSuccess();
  });
}

showSuccess() {
  this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Question Posted' });
}

private modalService = inject(NgbModal);
modalRef!: NgbModalRef;
openVerticallyCentered(content: TemplateRef<any>, question?:Ask) {
  if(question) this.updateAskModel={
    id:question.id,
    title:question.title,
    content:question.content??'',
  };
  this.modalRef = this.modalService.open(content, { centered: true,size:'lg', });
}

pickedQuestion!:Ask;
openQuestionModal(content: TemplateRef<any>,question:Ask) {
  console.log(question);
  this.pickedQuestion=question;
  this.modalService.open(content, {scrollable: true, centered: true,size:'lg' });
}

closeModal() {
  console.log("closing modal");

  if(this.modalRef){
    this.modalRef.close();
  }
}


}
