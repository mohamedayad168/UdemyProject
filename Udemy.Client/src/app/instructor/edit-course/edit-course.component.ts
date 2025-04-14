import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { InstructorService } from '../../services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';
import { Course } from '../../lib/models/course.model';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../lib/services/course.service';
@Component({
  selector: 'app-edit-course',
  imports: [CommonModule,RouterModule],
  templateUrl: './edit-course.component.html',
  styleUrl: './edit-course.component.css'
})
export class EditCourseComponent  implements OnInit {
  instructorId!: number;
  courses: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService,
    private instructorservice: InstructorService
  ) {}

  ngOnInit(): void {
    this.instructorId = +this.route.snapshot.paramMap.get('id')!;
    this.instructorservice.getInstructorCourses(this.instructorId).subscribe({
      next: (data) => {
        this.courses = data;
      },
      error: (err) => {
        console.error('Error fetching instructor courses:', err);
      }
    });
  }
  deleteCourse(courseId: number): void {
    if (confirm('Are you sure you want to delete this course?')) {
      this.courseService.deleteCourse(courseId).subscribe({
        next: () => {
          this.courses = this.courses.filter(c => c.id !== courseId);
          alert('Course deleted successfully.');
        },
        error: (err) => {
          console.error('Error deleting course:', err);
          alert('Failed to delete course.');
        }
      });
    }
  }
}