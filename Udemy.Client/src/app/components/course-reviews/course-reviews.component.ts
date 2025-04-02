import { Component, input } from '@angular/core';
import { CourseRating, dummyRatings, rating } from '../../models/review';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RatingModule } from 'primeng/rating';
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

    ngOnInit() {
        console.log("Course ID: ", this.courseId());
        this.courseRating=dummyRatings;
        console.log("Course Ratings: ", this.courseRating);
        this.rating=this.courseRating.rating;

    }

}
