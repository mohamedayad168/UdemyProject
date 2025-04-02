import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CourseService } from '../services/course.service';
import { Course } from '../models/course.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-learners-viewing',
  imports: [CommonModule],
  templateUrl: './learners-viewing.component.html',
  styleUrl: './learners-viewing.component.css'
})
export class LearnersViewingComponent   implements OnInit {
  courses: Course[] = [];
  hoveredCourse: Course | null = null;
  @ViewChild('courseContainer', { static: false }) courseContainer!: ElementRef;

  constructor(private courseService: CourseService, private router: Router) {}

  ngOnInit(): void {
    this.courseService.getCourses().subscribe(
      (data: Course[]) => {
        this.courses = data;
      },
      (error) => {
        console.error('Error fetching courses:', error);
      }
    );
  }

  showOverlay(course: Course): void {
    this.hoveredCourse = course;
  }

  hideOverlay(): void {
    this.hoveredCourse = null;
  }

  goToDetails(courseId: number): void {
    this.router.navigate(['/course-details', courseId]);
  }

  scrollLeft(): void {
    this.courseContainer.nativeElement.scrollBy({ left: -300, behavior: 'smooth' });
  }

  scrollRight(): void {
    this.courseContainer.nativeElement.scrollBy({ left: 300, behavior: 'smooth' });
  }
}

