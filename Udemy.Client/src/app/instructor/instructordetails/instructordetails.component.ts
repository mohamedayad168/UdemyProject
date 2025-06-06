import { Component, OnInit } from '@angular/core';
import { InstructorService } from '../../lib/services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

import { CourseService } from '../../lib/services/course.service';
import { environment } from '../../../environments/environment';
import { Course } from '../../lib/models/course.model';
import { AccountService } from '../../lib/services/account.service';
import { User } from '../../lib/models/user.model';

@Component({
  selector: 'app-instructordetails',
  imports: [CommonModule, RouterLink],
  templateUrl: './instructordetails.component.html',
  styleUrl: './instructordetails.component.css',
})
export class InstructordetailsComponent implements OnInit {
  instructorId!: number;
  instructor!: Instructor;
  courses: Course[] = [];
  currentUser: User | null;
  currentInstructorId: number = 0;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private courseService: CourseService,
    private instructorService: InstructorService,
    private accountService: AccountService
  ) {
    this.currentUser = this.accountService.currentUser();
  }

  ngOnInit(): void {
    this.currentInstructorId = Number(localStorage.getItem('instructorId')) || 0;
    this.route.params.subscribe((params) => {
      this.instructorId = +params['id'];
      this.fetchInstructorDetails();
      this.fetchInstructorCourses();
    });
  }

  fetchInstructorDetails(): void {
    this.instructorService.getInstructorDetails(this.instructorId).subscribe({
      next: (response) => {
        this.instructor = response;
      },
      error: (error) => {
        console.error('Error fetching instructor details:', error);
      },
    });
  }

  isOwner(): boolean {
    return this.currentInstructorId === this.instructorId;
  }

  deleteCourse(courseId: number): void {
    if (confirm('Are you sure you want to delete this course?')) {
      this.courseService.deleteCourse(courseId).subscribe({
        next: () => {
          this.courses = this.courses.filter((course) => course.id !== courseId);
          this.instructor.totalCourses = this.courses.length;
          alert('Course deleted successfully.');
        },
        error: (err) => {
          console.error('Error deleting course:', err);
          alert('Failed to delete course.');
        },
      });
    }
  }

  editCourse(courseId: number): void {
    this.router.navigate([`/updatecoursedetails/${courseId}`]);
  }

  fetchInstructorCourses(): void {
    this.instructorService.getInstructorCourses(this.instructorId).subscribe({
      next: (response) => {
        this.courses = response.map((course) => {
          if (course.imageUrl && !course.imageUrl.startsWith('http')) {
            course.imageUrl = `${environment.baseurl}/images/courses/${course.imageUrl}`;
          }
          return course;
        });
      },
      error: (error) => {
        console.error('Error fetching instructor courses:', error);
      },
    });
  }
}