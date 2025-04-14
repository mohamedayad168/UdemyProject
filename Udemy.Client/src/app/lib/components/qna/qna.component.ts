import { Component, inject, input, signal, TemplateRef } from '@angular/core';
import { ButtonDirective, CardBodyComponent, CardComponent, CollapseDirective } from '@coreui/angular';
import { ReadMoreComponent } from "../read-more/read-more.component";
import { FormsModule } from '@angular/forms';
import { Ask, CreateAsk } from '../../models/ask';
import { AskAnswerService } from '../../services/QNA/ask-answer.service';
import { CommonModule } from '@angular/common';
import { Toast } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { Dialog } from 'primeng/dialog';
import { Button, ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-qna',
  imports: [ReadMoreComponent,FormsModule,CommonModule,Toast,Dialog,Button],
  templateUrl: './qna.component.html',
  styleUrl: './qna.component.css',
  providers: [MessageService]
})
export class QNAComponent {
  askModel:CreateAsk={title:'',content:''};
  askService:AskAnswerService=inject(AskAnswerService);
  courseQuestions!:Array<Ask>;
  courseId=input<number>();
  pollingInterval!: any;
  pageNumber=1;
  pageSize=5;
  isLastPage=false;


  constructor(private messageService: MessageService) {}

  ngOnInit() {
    this.loadData();
    // this.pollingInterval = setInterval(() => {
    //   this.loadData(); // method to call your service and update the view
    // }, 5000);

  }

  ngOnDestroy() {
    clearInterval(this.pollingInterval);
  }

  loadData() {
    this.isLastPage=false;
    this.pageNumber=1;
    const courseId=this.courseId();
    if(courseId==undefined) return;
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
  this.askService.getCourseQnA(courseId,this.pageNumber,this.pageSize).subscribe((data:Array<Ask>) => {
    console.log('Questions received', data);
    if (data) {
      this.courseQuestions.push(...data);
      this.pageNumber++;
    }
    if(data.length<this.pageSize) this.isLastPage=true;
  })
}


submitReview() {
  console.log(`askModel: ${JSON.stringify(this.askModel)}`);

  this.askService.createAsk(this.courseId()!, this.askModel).subscribe((data) => {
    console.log('Question Posted to server', data);
    this.loadData();
    this.askModel={title:'',content:''};
    this.showSuccess();
    this.closeModal();

  });

}
showSuccess() {
  this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Question Posted' });
}

private modalService = inject(NgbModal);
modalRef!: NgbModalRef;
openVerticallyCentered(content: TemplateRef<any>) {
  this.modalRef = this.modalService.open(content, { centered: true });
}

closeModal() {
  console.log("closing modal");

  if(this.modalRef){
    this.modalRef.close();
  }
}


}
