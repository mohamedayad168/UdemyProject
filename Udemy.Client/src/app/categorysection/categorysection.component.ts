import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CommonModule } from '@angular/common';
import { Course } from '../models/course.model';
import { CourseService } from '../services/course.service';
import { CategoryService } from '../services/category.service';
@Component({
  selector: 'app-categorysection',
  imports: [CommonModule],
  templateUrl: './categorysection.component.html',
  styleUrl: './categorysection.component.css'
})
export class CategorysectionComponent implements OnInit {
  categories: Category[] = [];
  courses: Course[] = [];
  categoryCourses: { [categoryId: number]: Course[] } = {}; // Stores courses for each category

  constructor(
    private categoryService: CategoryService,
    private courseService: CourseService
  ) {}

  ngOnInit(): void {
    this.loadCategoriesAndCourses();
  }

  private loadCategoriesAndCourses(): void {
    this.categoryService.getCategories().subscribe(
      (categoriesData) => {
        this.categories = categoriesData;
        this.courseService.getCourses().subscribe(
          (coursesData) => {
            this.courses = coursesData;
            this.mapCoursesToCategories();
          },
          (error) => console.error('Error fetching courses', error)
        );
      },
      (error) => console.error('Error fetching categories', error)
    );
  }

  private mapCoursesToCategories(): void {
    this.categories.forEach((category) => {
      this.categoryCourses[category.id] = this.courses
        .filter(course => course.subCategory.id === category.id) // Match category with courses
        .slice(0, 5); // Show only 5 courses per category
    });
  }

}