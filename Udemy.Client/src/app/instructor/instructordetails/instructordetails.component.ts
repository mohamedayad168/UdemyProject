import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { InstructorService } from '../../services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { CourseService } from '../../lib/services/course.service';
import { environment } from '../../../environments/environment';
import { Course } from '../../lib/models/course.model';

@Component({
  selector: 'app-instructordetails',
  imports: [CommonModule,RouterLink],
  templateUrl: './instructordetails.component.html',
  styleUrl: './instructordetails.component.css'
})
export class InstructordetailsComponent implements OnInit {
  instructorId!: number;
  instructor!: Instructor;
  courses: Course[] = [];

  constructor(private route: ActivatedRoute, private instructorService: InstructorService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.instructorId = +params['id'];
      this.fetchInstructorDetails();
      this.fetchInstructorCourses();
    });
  }



  fetchInstructorDetails(): void {
    console.log('Fetching instructor details for ID:', this.instructorId);
    this.instructorService.getInstructorDetails(this.instructorId).subscribe({
      next: (response) => {
        this.instructor = response;
        console.log('Instructor details:', this.instructor);
      },
      error: (error) => {
        console.error('Error fetching instructor details:', error);
      }
    });
  }
  
  fetchInstructorCourses(): void {
    console.log('Fetching courses for instructor ID:', this.instructorId);
    this.instructorService.getInstructorCourses(this.instructorId).subscribe({
      next: (response) => {
        this.courses = response.map(course => {
          if (course.imageUrl && !course.imageUrl.startsWith('http')) {
            course.imageUrl = `${environment.baseurl}/images/courses/${course.imageUrl}`;
          }
          return course;
        });
        console.log('Courses:', this.courses);
      },
      error: (error) => {
        console.error('Error fetching instructor courses:', error);
      }
    });
  }
}  