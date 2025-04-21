import { Component, inject } from '@angular/core';
import { CourseDetailsPageComponent } from "../../pages/course-details-page/course-details-page.component";
import { QuestionAnswersComponent } from "../../lib/components/question-answers/question-answers.component";
import { ActivatedRoute } from '@angular/router';
import { QNAComponent } from "../../lib/components/qna/qna.component";

@Component({
  selector: 'app-course-view-engagment',
  imports: [QuestionAnswersComponent, QNAComponent],
  templateUrl: './course-view-engagment.component.html',
  styleUrl: './course-view-engagment.component.css'
})
export class CourseViewEngagmentComponent {
  activatedRoute = inject(ActivatedRoute);
  courseId!:number;
  ngOnInit(){
    const courseId: number = this.activatedRoute.snapshot.params['id'];
    if(courseId){
      this.courseId=courseId;
      console.log(`course id is ${this.courseId}`);

    }

  }

}
