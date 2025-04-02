import { Component } from '@angular/core';
import { InstructorBioComponent } from "../instructor-bio/instructor-bio.component";
import { CourseReviewsComponent } from '../course-reviews/course-reviews.component';
import {  CourseDetail, dummyCourseDetails } from '../../types/CourseDetail';
import { CommonModule} from '@angular/common';
import { CdkAccordionModule } from '@angular/cdk/accordion';

@Component({
  selector: 'app-course-details',
  imports: [CommonModule,
    CourseReviewsComponent, InstructorBioComponent,CdkAccordionModule],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.css'
})
export class CourseDetailsComponent {

  courseDetails:CourseDetail;

  constructor() {
    // Initialize course details with dummy data
    this.courseDetails = dummyCourseDetails;
  }


  ngOnInit() {
    // Simulate fetching course details from a service
    console.log("Course Details: ", this.courseDetails);

  }

  get numberOfSections(): number {
    return this.courseDetails.courseContent.sections.length;
  }

  get numberOfLessons(): number {
    return this.courseDetails.courseContent.sections.reduce((total, section) => {
      return total + section.lessons.length;
    }, 0);
  }


}
