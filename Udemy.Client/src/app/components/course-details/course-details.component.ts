import { Component, inject } from '@angular/core';
import { InstructorBioComponent } from "../instructor-bio/instructor-bio.component";
import { CourseReviewsComponent } from '../course-reviews/course-reviews.component';
import {  CourseDetail, dummyCourseDetails } from '../../models/CourseDetail.model';
import { CommonModule} from '@angular/common';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CourseService } from '../../services/course.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

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
  router=inject(Router);
  route=inject(ActivatedRoute);



  ngOnInit() {
    // Simulate fetching course details from a service
    const courseId:number=this.activatedRoute.snapshot.params['id'];
    this.courseService.getCourseById(courseId,true)
    .pipe(
      catchError((error) => {
        console.error('Error fetching course details:', error);
        // Handle the error here, e.g., navigate to a 404 page or show an error message
        this.router.navigate(['/not-found']);
        return throwError('Something went wrong');
      })
    )
    .subscribe((data?:CourseDetail) => {
      if(data){
        this.courseDetails=data;
        console.log("bad data",data);

      }
      else{
        // route to a 404 page or show an error message
        this.router.navigate(['/not-found']);
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
