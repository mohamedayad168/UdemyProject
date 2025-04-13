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

  selectedCategoryId: number | null = null;
  selectedSubcategoryId: number | null = null;

  @ViewChild('scrollContainer') scrollContainer!: ElementRef;

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

      if (this.categories.length > 0) {
        this.selectedCategoryId = this.categories[0].id;
        this.onCategoryClick(this.selectedCategoryId);
      }
    });
  }

  onCategoryClick(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.selectedSubcategoryId = null;
    this.courses = [];

    this.categoryService.getSubcategoriesByCategory(categoryId).subscribe((data) => {
      this.subcategories = data;

      if (this.subcategories.length > 0) {
        this.selectedSubcategoryId = this.subcategories[0].id;
        this.loadCoursesBySubcategory(this.selectedSubcategoryId);
      }
    });
  }

  onSubcategoryClick(subcategoryId: number) {
    this.selectedSubcategoryId = subcategoryId;
    this.loadCoursesBySubcategory(subcategoryId);
  }

  loadCoursesBySubcategory(subcategoryId: number | null): void {
    if (subcategoryId !== null) {
      this.categoryService.getCoursesBySubcategory(subcategoryId).subscribe(
        (courses: Course[]) => {
          this.courses = courses;
        },
        (error) => {
          console.error('Error fetching courses by subcategory', error);
        }
      );
    }
  }

  scroll(direction: 'left' | 'right') {
    const container = this.scrollContainer.nativeElement;
    const scrollAmount = 340;
    container.scrollBy({
      left: direction === 'left' ? -scrollAmount : scrollAmount,
      behavior: 'smooth',
    });
  }
}