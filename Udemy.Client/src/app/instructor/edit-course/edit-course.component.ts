import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { InstructorService } from '../../lib/services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';
import { Course } from '../../lib/models/course.model';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../lib/services/course.service';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../lib/services/account.service';
@Component({
  selector: 'app-edit-course',
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './edit-course.component.html',
  styleUrl: './edit-course.component.css',
})
export class EditCourseComponent implements OnInit {
  instructorId: number | undefined;
  courses: Course[] = [];
  filteredCourses: Course[] = [];
  searchQuery: string = '';
  instructor!: Instructor;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService,
    private instructorService: InstructorService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.instructorId = this.accountService.currentUser()?.id;
    // Fetch instructor and their courses
    this.instructorService.getInstructorById(this.instructorId!).subscribe({
      next: (instructorData) => {
        this.instructor = instructorData;
        this.getInstructorCourses();
      },
      error: (err) => {
        console.error('Error fetching instructor:', err);
      },
    });
  }

  getInstructorCourses(): void {
    this.instructorService.getInstructorCourses(this.instructorId!).subscribe({
      next: (data) => {
        this.courses = data;
        this.filteredCourses = this.courses; // Initially show all courses
      },
      error: (err) => {
        console.error('Error fetching instructor courses:', err);
      },
    });
  }

  filterCourses(): void {
    // Filter courses based on the search query
    this.filteredCourses = this.courses.filter((course) =>
      course.title.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
  }

  deleteCourse(courseId: number): void {
    if (confirm('Are you sure you want to delete this course?')) {
      this.courseService.deleteCourse(courseId).subscribe({
        next: () => {
          // Remove the course from the list
          this.courses = this.courses.filter((c) => c.id !== courseId);
          this.filteredCourses = this.courses; // Update filtered courses
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
}
