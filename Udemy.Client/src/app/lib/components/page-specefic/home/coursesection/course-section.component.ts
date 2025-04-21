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
import { Router, RouterLink } from '@angular/router';
import { CategoryService } from '../../../../services/category.service';
import { CourseDetail } from '../../../../models/CourseDetail.model';
import { AccountService } from '../../../../services/account.service';
import { CartService } from '../../../../services/cart/cart.service';
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
  isCourseAdded: boolean = false;
  selectedCategoryId: number | null = null;
  selectedSubcategoryId: number | null = null;

  @ViewChild('scrollContainer') scrollContainer!: ElementRef;
  @ViewChild('categoryScroll') categoryScroll!: ElementRef;
  @ViewChild('subcategoryScroll') subcategoryScroll!: ElementRef;
 
  constructor(
    private categoryService: CategoryService,
    private courseService: CourseService,
    private accountService: AccountService,
    private cartService: CartService,
    private router: Router
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

  // Scroll left or right for categories
  scrollCategory(direction: string): void {
    const container = this.categoryScroll.nativeElement;
    const scrollAmount = 300; // Customize this value for scroll amount
    if (direction === 'left') {
      container.scrollLeft -= scrollAmount;
    } else {
      container.scrollLeft += scrollAmount;
    }
  }

  // Scroll left or right for subcategories
  scrollSubcategory(direction: 'left' | 'right'): void {
    const container = this.subcategoryScroll.nativeElement;
    const scrollAmount = 300; // Customize this value for scroll amount
    if (direction === 'left') {
      container.scrollLeft -= scrollAmount;
    } else {
      container.scrollLeft += scrollAmount;
    }
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

  addCourseToStudentCart(courseId: number) {
    if (!this.accountService.currentUser()) {
      this.router.navigateByUrl('/login');
     
    } else {
      this.cartService.addCourseToStudentCart(courseId);
    }
    this.isCourseAdded = true;
    setTimeout(() => {
      this.isCourseAdded = false;
    }, 3000);
  }
  
  scrollCourses(direction: 'left' | 'right') {
    const scrollAmount = 300;
    this.scrollContainer.nativeElement.scrollBy({
      left: direction === 'left' ? -scrollAmount : scrollAmount,
      behavior: 'smooth',
    });
  }
  goToCourseDetail(courseId: number) {
    this.router.navigate(['/courses', courseId]);
  }
  
}