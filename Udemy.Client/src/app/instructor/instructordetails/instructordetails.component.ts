import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { InstructorService } from '../../services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { CourseService } from '../../lib/services/course.service';

@Component({
  selector: 'app-instructordetails',
  imports: [CommonModule,RouterLink],
  templateUrl: './instructordetails.component.html',
  styleUrl: './instructordetails.component.css'
})
export class InstructordetailsComponent implements OnInit {
  instructorId!: number;
  instructor: any = null;
  courses: any[] = [];

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.instructorId = +params['id']; // Convert param to number
      this.fetchInstructorDetails();
      this.fetchInstructorCourses();
    });
  }

  // Fetch instructor details
  fetchInstructorDetails(): void {
    this.http
      .get<any>(
        `http://localhost:5191/api/instructors/details?instructorId=${this.instructorId}`
      )
      .subscribe(
        (response) => {
          this.instructor = response;
          console.log('Instructor details:', this.instructor);
        },
        (error) => {
          console.error('Error fetching instructor details:', error);
        }
      );
  }

  // Fetch instructor's courses
  fetchInstructorCourses(): void {
    this.http
      .get<any[]>(
        `http://localhost:5191/api/instructors/${this.instructorId}/courses`
      )
      .subscribe(
        (response) => {
          // Fix image paths
          this.courses = response.map((course) => {
            if (course.imageUrl && !course.imageUrl.startsWith('http')) {
              course.imageUrl = `http://localhost:5191/images/courses/${course.imageUrl}`;
            }
            return course;
          });
          console.log('Courses:', this.courses);
        },
        (error) => {
          console.error('Error fetching instructor courses:', error);
        }
      );
  }

  // Add scroll helpers for left/right arrows
  scrollLeft(container: HTMLElement): void {
    container.scrollBy({ left: -300, behavior: 'smooth' });
  }

  scrollRight(container: HTMLElement): void {
    container.scrollBy({ left: 300, behavior: 'smooth' });
  }
}