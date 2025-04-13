import { Component, inject, input } from '@angular/core';
import { Instructor } from '../../models/instructor.model';
import { InstructorServiceService } from '../../services/instructor-service.service';
import { Router } from '@angular/router';
import { CourseDetail } from '../../models/CourseDetail.model';

@Component({
  selector: 'app-course-over-view',
  imports: [],
  templateUrl: './course-over-view.component.html',
  styleUrl: './course-over-view.component.css'
})
export class CourseOverViewComponent {
  courseDetails = input<CourseDetail>();
  instructor!: Instructor;
  instructorService: InstructorServiceService;
  router=inject(Router);
  constructor(instructorService: InstructorServiceService) {
    this.instructorService = instructorService;
  }

  ngOnInit() {
    const instructorId = this.courseDetails()?.instructor.id;
    if (instructorId === undefined) {
      console.error('Instructor ID is undefined.');
      return;
    }
    this.instructorService
      .getInstructorById(instructorId)
      .subscribe((data: Instructor) => {
        if (data) {
          this.instructor = data;
        } else {
          console.error('No data received for instructor.');
          this.router.navigate(['/not-found']);
          // route to a 404 page or show an error message
        }
      });
  }

get numOfLectures(){

  return this.courseDetails()?.sections.reduce((total, section) => {
    return total + section.lessons.length;
  }, 0);
}


}
