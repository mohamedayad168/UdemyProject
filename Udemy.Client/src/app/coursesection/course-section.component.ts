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
  filteredCourses: Course[] = []; // Filtered courses to be displayed
  categories: Category[] = [];
  selectedCategory: string = ''; // Name of selected category

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.loadCategories();
    this.loadCourses();
  }

  loadCategories(): void {
    this.courseService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
      if (this.categories.length > 0) {
        this.selectedCategory = this.categories[0].name; // Default selected category
        this.filterCourses(); // Filter courses based on the default category
      }
    });
  }

  loadCourses(): void {
    this.courseService.getCourses().subscribe({
      next: (data) => {
        this.courses = data;
        this.filterCourses(); // Filter courses whenever they are loaded
      },
      error: (err) => console.error('Error loading courses:', err)
    });
  }

  selectCategory(category: string): void {
    this.selectedCategory = category;
    this.filterCourses(); // Filter courses when a category is selected
  }

  filterCourses(): void {
    // Filter courses by subCategory.name
    this.filteredCourses = this.courses.filter(course => course.subCategory.name === this.selectedCategory);
  }
}
