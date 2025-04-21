import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  signal,
} from '@angular/core';
import { CourseService } from '../../../../services/course.service';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { Course } from '../../../../models/course.model';
import { Category, SubCategory } from '../../../../models/category.model';
import { Carousel } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { Tag, TagModule } from 'primeng/tag';
import { Rating } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CategoryService } from '../../../../services/category.service';
import { CourseDetail } from '../../../../models/CourseDetail.model';
import { AccountService } from '../../../../services/account.service';
import { CartService } from '../../../../services/cart/cart.service';
import { MatTabChangeEvent, MatTabsModule } from '@angular/material/tabs';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { SubcategoryCourseComponent } from '../subcategory-course/subcategory-course.component';
import { CarouselModule } from 'primeng/carousel';
import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';

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
    MatTabsModule,
    MatProgressSpinner,
    SubcategoryCourseComponent,
    CarouselModule,
    NgbRatingModule,
    CurrencyPipe,
  ],
})
export class CourseSectionComponent implements OnInit {
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  courses: Course[] = [];
  isCourseAdded: boolean = false;
  isLoadingSubCategoryCourses = false;
  isLoadingSubCategories = false;
  selectedCategoryId: number | null = null;
  selectedSubcategoryId: number | null = null;
  subCategoryFixedCourseLength = 4;
  subCategoryFixedCourseStart = 0;
  subCategoryFixedCourses: Course[] = [];
  isPrev = false;
  isNext = true;

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
    });
  }

  onCategoryChange(event: MatTabChangeEvent) {
    this.isLoadingSubCategories = true;

    const categoryId = this.categories[event.index].id;
    this.selectedCategoryId = categoryId;
    this.selectedSubcategoryId = null;
    this.courses = [];

    this.categoryService
      .getSubcategoriesByCategory(categoryId)
      .subscribe((data) => {
        this.isLoadingSubCategories = false;
        this.subcategories = data;
        if (this.subcategories.length > 0) {
          this.selectedSubcategoryId = this.subcategories[0].id;
          this.loadCoursesBySubcategory(this.selectedSubcategoryId);
        }
      });
  }

  onSubcategoryChange(event: MatTabChangeEvent) {
    const subCategoryId = this.subcategories[event.index].id;
    this.selectedSubcategoryId = subCategoryId;
    this.loadCoursesBySubcategory(subCategoryId);
  }

  loadCoursesBySubcategory(subcategoryId: number | null): void {
    if (subcategoryId !== null) {
      this.isLoadingSubCategoryCourses = true;
      this.categoryService.getCoursesBySubcategory(subcategoryId).subscribe(
        (courses: Course[]) => {
          this.isLoadingSubCategoryCourses = false;
          this.courses = courses;
          this.initSubCategoryCoursesFixedItem();

          this.subCategoryFixedCourses = this.courses.slice(
            this.subCategoryFixedCourseStart,
            this.subCategoryFixedCourseLength
          );
        },
        (error) => {
          console.error('Error fetching courses by subcategory', error);
        }
      );
    }
  }

  initSubCategoryCoursesFixedItem() {
    this.subCategoryFixedCourseLength = 4;
    this.subCategoryFixedCourseStart = 0;

    this.subCategoryFixedCourses = this.courses.slice(
      this.subCategoryFixedCourseStart,
      this.subCategoryFixedCourseStart + this.subCategoryFixedCourseLength
    );

    this.isPrev = false;
    this.isNext = true;
  }

  setNextFlag() {
    this.isNext =
      this.subCategoryFixedCourseStart + this.subCategoryFixedCourseLength <
      this.courses.length;
  }

  setPreviousFlag() {
    this.isPrev =
      this.subCategoryFixedCourseStart - this.subCategoryFixedCourseLength >= 0;
  }

  onMoveCoursesNext() {
    if (this.isNext) {
      this.subCategoryFixedCourseStart += this.subCategoryFixedCourseLength;

      this.setNextFlag();
      this.setPreviousFlag();

      this.subCategoryFixedCourses = this.courses.slice(
        this.subCategoryFixedCourseStart,
        this.subCategoryFixedCourseStart + this.subCategoryFixedCourseLength
      );
    }
  }

  onMoveCoursesPrevious() {
    if (this.isPrev) {
      this.subCategoryFixedCourseStart -= this.subCategoryFixedCourseLength;

      this.setNextFlag();
      this.setPreviousFlag();

      this.subCategoryFixedCourses = this.courses.slice(
        this.subCategoryFixedCourseStart,
        this.subCategoryFixedCourseStart + this.subCategoryFixedCourseLength
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
      this.isCourseAdded = false; // Hide message after 3 seconds
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
