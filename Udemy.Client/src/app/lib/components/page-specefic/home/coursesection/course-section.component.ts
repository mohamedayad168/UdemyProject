import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CourseService } from '../../../../services/course.service';
import { CommonModule } from '@angular/common';
import { Course } from '../../../../models/course.model';
import { Category, SubCategory } from '../../../../models/category.model';
import { Carousel } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { Tag } from 'primeng/tag';
import { Rating } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CategoryService } from '../../../../services/category.service';

@Component({
  selector: 'app-course-section',
  templateUrl: './course-section.component.html',
  styleUrls: ['./course-section.component.css'],
  imports: [
    FormsModule,
    Rating,
    CommonModule,
    Carousel,
    ButtonModule,
    Tag,
    RouterLink,
  ],
})
export class CourseSectionComponent implements OnInit {
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  courses: Course[] = [];

  // Update the type to allow null
  selectedCategoryId: number | null = null;
  selectedSubcategoryId: number | null = null;  // Allow null for subcategoryId

  constructor(
    private categoryService: CategoryService,
    private courseService: CourseService
  ) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;

      // Select the first category by default
      if (this.categories.length > 0) {
        this.selectedCategoryId = this.categories[0].id;
        this.onCategoryClick(this.selectedCategoryId); // Automatically load subcategories and courses
      }
    });
  }

  onCategoryClick(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.selectedSubcategoryId = null; // Reset to null when category is clicked
    this.courses = []; // Clear courses when a new category is selected

    // Get subcategories for the selected category
    this.categoryService.getSubcategoriesByCategory(categoryId).subscribe((data) => {
      this.subcategories = data;

      // Select the first subcategory by default if there are subcategories
      if (this.subcategories.length > 0) {
        this.selectedSubcategoryId = this.subcategories[0].id;
        this.loadCoursesBySubcategory(this.selectedSubcategoryId); // Load courses for the first subcategory
      }
    });
  }

  onSubcategoryClick(subcategoryId: number) {
    this.selectedSubcategoryId = subcategoryId;
    this.loadCoursesBySubcategory(subcategoryId);  // Load courses for the selected subcategory
  }

  // Load courses based on subcategory ID
  loadCoursesBySubcategory(subcategoryId: number | null): void {
    if (subcategoryId !== null) {
      this.categoryService.getCoursesBySubcategory(subcategoryId).subscribe(
        (courses: Course[]) => {
          this.courses = courses;
        },
        (error) => {
          console.error('Error fetching courses by subcategory:', error.message);
          console.error('Status:', error.status);
          console.error('Full error:', error);
        }
      );
    }
  }

 
  onSubcategoryChange(subcategoryId: number): void {
    this.selectedSubcategoryId = subcategoryId;
    this.loadCoursesBySubcategory(subcategoryId); 
  }
  scrollLeft(container: HTMLElement) {
    container.scrollBy({ left: -300, behavior: 'smooth' });
  }
  
  scrollRight(container: HTMLElement) {
    container.scrollBy({ left: 300, behavior: 'smooth' });
  }
  
}
