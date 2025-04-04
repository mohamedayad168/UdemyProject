import { Component, inject, input } from '@angular/core';
import { CourseRating, dummyRatings, rating } from '../../models/review';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RatingModule } from 'primeng/rating';
import { ReviewServiceService } from '../../services/review-service.service';
@Component({
  selector: 'app-course-reviews',
  imports: [CommonModule, FormsModule,RatingModule
  ],
  templateUrl: './course-reviews.component.html',
  styleUrl: './course-reviews.component.css'
})
export class  CourseReviewsComponent {

    courseId=input<number>();
    courseRating!:CourseRating;
    rating!: number;
    reviewService=inject(ReviewServiceService)

    ngOnInit() {
      const courseId = this.courseId();
      if (courseId === undefined) {
        console.error("Course ID is undefined.");
        this.courseRating = dummyRatings;
        return;
      }
      this.reviewService.getCourseRatings(courseId).subscribe((data:CourseRating) => {
        if(data){
          console.log("data received",data);

          this.courseRating=data;
        }
        else{
          console.error("No data received for course ratings.");
          this.courseRating = dummyRatings;
          // route to a 404 page or show an error message
        }
      })


    }

}
