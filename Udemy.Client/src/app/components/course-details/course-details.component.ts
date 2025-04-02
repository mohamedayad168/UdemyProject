import { Component, inject } from '@angular/core';
import { InstructorBioComponent } from "../instructor-bio/instructor-bio.component";
import { CourseReviewsComponent } from '../course-reviews/course-reviews.component';
import {  CourseDetail, dummyCourseDetails } from '../../models/CourseDetail.model';
import { CommonModule} from '@angular/common';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-course-details',
  imports: [CommonModule,
    CourseReviewsComponent, InstructorBioComponent,CdkAccordionModule],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.css'
})
export class CourseDetailsComponent {

  courseDetails!:CourseDetail;
  activatedRoute=inject(ActivatedRoute);
  courseService=inject(CourseService);



  ngOnInit() {
    // Simulate fetching course details from a service
    const courseId:number=this.activatedRoute.snapshot.params['id'];
    this.courseService.getCourseById(courseId,true).subscribe((data:CourseDetail) => {
      if(data){
        this.courseDetails=data;
      }
      else{
        console.error("No data received for course details.");
        this.courseDetails = dummyCourseDetails;
        // route to a 404 page or show an error message
      }

    });


  }

  get numberOfSections(): number {
    return this.courseDetails?.sections.length ?? 0;
  }

  get numberOfLessons(): number {
    return this.courseDetails?.sections.reduce((total, section) => {
      return total + section.lessons.length;
    }, 0) ?? 0;
  }


}
