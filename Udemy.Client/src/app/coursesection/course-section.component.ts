import { Component, OnInit } from '@angular/core';
import { CourseService } from '../services/course.service';
import { CommonModule } from '@angular/common';
import { Course } from '../models/course.model';
import { Category } from '../models/category.model';
@Component({
  selector: 'app-course-section',
  templateUrl: './course-section.component.html',
  styleUrls: ['./course-section.component.css'],
  imports: [CommonModule] 
})
export class CourseSectionComponent implements OnInit {
  courses: Course[] = [];
  categories: Category[] = []; 
  selectedCategory: string = '';

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.loadCategories();
    this.loadCourses();
  }

  loadCategories(): void {
    this.courseService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
      if (this.categories.length > 0) {
        this.selectedCategory = this.categories[0].name;
      }
    });
  }

  loadCourses(): void {
    this.courseService.getCourses().subscribe({
      next: (data) => this.courses = data,
      error: (err) => console.error('Error loading courses:', err)
    });
  }

  selectCategory(category: string): void {
    this.selectedCategory = category;
  }
}