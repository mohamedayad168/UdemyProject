import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CourseService } from '../../../../services/course.service';
import { CommonModule } from '@angular/common';
import { Course } from '../../../../models/course.model';
import { Category } from '../../../../models/category.model';
import { Carousel } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { Tag } from 'primeng/tag';
import { Rating } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

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
  courses: Course[] = [];
  filteredCourses: Course[] = []; // Filtered courses to be displayed
  categories: Category[] = [];
  selectedCategory: number | null = null; // Name of selected category

  @ViewChild('categoryContainer') categoryContainer!: ElementRef;
  @ViewChild('courseContainer') courseContainer!: ElementRef;

  //carousel
  responsiveOptions: any[] | undefined;
  getSeverity(status: string) {
    switch (status) {
      case 'INSTOCK':
        return 'success';
      case 'LOWSTOCK':
        return 'warn';
      default:
        return 'danger';
    }
  }

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.loadCategories();
    this.loadCourses();

    this.responsiveOptions = [
      {
        breakpoint: '1400px',
        numVisible: 4,
        numScroll: 1,
      },
      {
        breakpoint: '1199px',
        numVisible: 3,
        numScroll: 1,
      },
      {
        breakpoint: '767px',
        numVisible: 2,
        numScroll: 1,
      },
      {
        breakpoint: '575px',
        numVisible: 1,
        numScroll: 1,
      },
    ];
  }
  loadCategories(): void {
    this.courseService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
      console.log('Loaded Categories:', this.categories); // Log loaded categories
      if (this.categories.length > 0) {
        this.selectedCategory = 1;
        // this.filterCourses();
      }
    });
  }

  loadCourses(): void {
    this.courseService.getCoursesByCategory(1).subscribe({
      next: (data) => {
        this.filteredCourses = data;
        console.log('Loaded Courses:', this.courses); // Log loaded courses
        // this.filterCourses(); // Filter courses whenever they are loaded
      },
      error: (err) => console.error('Error loading courses:', err),
    });
  }

  selectCategory(category: Category): void {
    this.selectedCategory = category.id;

    this.courseService.getCoursesByCategory(category.id).subscribe({
      next: (data) => {
        this.filteredCourses = data;
        console.log('courses by category:'+category.id, this.courses); // Log loaded courses
        // this.filterCourses(); // Filter courses whenever they are loaded
      },
      error: (err) => console.error('Error loading courses:', err),
    })
    // this.filterCourses(); // Filter courses when a category is selected
  }

  // filterCourses(): void {
  //   console.log('Selected Category:', this.selectedCategory); // Log selected category
  //   this.filteredCourses = this.courses.filter((course) => {
  //     const subCategoryName = course.subCategory?.name || 'No Subcategory';

  //     // Find the category by name
  //     const category = this.categories.find(
  //       (cat) => cat.name === this.selectedCategory
  //     );

  //     // Check if the category exists and contains the subcategory
  //     if (category) {
  //       return (
  //         category.subcategories?.some((sub) => sub.name === subCategoryName) ||
  //         subCategoryName === 'No Subcategory'
  //       );
  //     }

  //     return false;
  //   });
  //   console.log('Filtered Courses:', this.filteredCourses); // Log the filtered list
  // }

  // filterCourses(): void {
  //   console.log('Selected Category:', this.selectedCategory); // Log selected category
  //   if (this.selectedCategory != null) {
  //     this.filteredCourses = this.courses.filter((course) => {
  //       return course.categoryId === this.selectedCategory;
  //     });
  //   } else {
  //     this.filteredCourses = this.courses;
  //   }
  // }
  scrollCategories(direction: string): void {
    const container = this.categoryContainer.nativeElement;
    if (direction === 'left') {
      container.scrollBy({ left: -300, behavior: 'smooth' });
    } else {
      container.scrollBy({ left: 300, behavior: 'smooth' });
    }
  }

  scrollCourses(direction: string): void {
    const container = this.courseContainer.nativeElement;
    if (direction === 'left') {
      container.scrollBy({ left: -300, behavior: 'smooth' });
    } else {
      container.scrollBy({ left: 300, behavior: 'smooth' });
    }
  }

  round(value: number): number {
    return Math.round(value - 0.2);
  }
}
