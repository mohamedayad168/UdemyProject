import { Component, input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Rating } from 'primeng/rating';
import { UserService } from '../../services/user.service';
import { PostReview } from '../../models/review';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-create-review',
  imports: [FormsModule,Rating],
  templateUrl: './create-review.component.html',
  styleUrl: './create-review.component.css'
})
export class CreateReviewComponent {
  reviewUpdated$=input<Subject<void>>();
  showReview=false;
  courseRating=input<PostReview>();
  private _userService:UserService;
  reviewModel!:PostReview;
  constructor(userService:UserService){
    this._userService=userService;
  }
  ngOnInit(){
    const courseId = this.courseRating()?.courseId;
    if (courseId === undefined) {
      console.error('Course ID is undefined.');
      return;
    }
    this.reviewModel = this.courseRating()??{
      courseId: courseId,
    };
    if(this.reviewModel.rating!=null){
      this.showReview=true;
    }
  }

  submitReview() {
  console.log(this.reviewModel);
    this._userService.postReview(this.reviewModel).subscribe((data) => {
      console.log('review Posted to server', data);
      this.reviewUpdated$()?.next();
    });
    this.showReview=true;
  }
  deleteReview() {
    console.log(this.reviewModel);
    this.reviewModel={
      courseId: this.reviewModel.courseId,
    }
      console.log("deletting review",this.reviewModel);
      this._userService.postReview(this.reviewModel).subscribe((data) => {
        console.log('review Posted to server', data);
      this.reviewUpdated$()?.next();

      });
      this.showReview=false;
  }
  editReview() {
    this.showReview=false;
  }




}
