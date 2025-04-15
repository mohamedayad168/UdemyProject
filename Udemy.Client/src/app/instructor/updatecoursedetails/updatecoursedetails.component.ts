import { Component, OnInit } from '@angular/core';
import { Course } from '../../lib/models/course.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { CourseDetail } from '../../lib/models/CourseDetail.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../../lib/services/category.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';

@Component({
  selector: 'app-updatecoursedetails',
  imports: [CommonModule,FormsModule],
  templateUrl: './updatecoursedetails.component.html',
  styleUrl: './updatecoursedetails.component.css'
})
export class UpdatecoursedetailsComponent implements OnInit {
  courseId!: number; 
  course: any = {}; 
  categories: any[] = []; // Store available categories
  subCategories: any[] = []; // Store available sub-categories
  
  constructor(
    private courseService: CourseService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.courseId = +params.get('id')!; // Extract course ID from URL
      this.loadCategories();
      this.loadCourseDetails();
    });
  }
  // Load categories from the category service
  loadCategories() {
    this.categoryService.getCategories().subscribe(
      (categories) => {
        this.categories = categories;
        // Optionally, set the category and sub-category based on the existing course details
        if (this.course.categoryId) {
          this.onCategoryChange(this.course.categoryId);
        }
      },
      (error) => {
        console.error('Error fetching categories', error);
      }
    );
  }

  // Handle category change and load corresponding sub-categories
  onCategoryChange(event: Event) {
    const categoryId = (event.target as HTMLSelectElement).value;
    this.course.categoryId = +categoryId; // Casting the value to a number using unary plus
  
    this.categoryService.getSubcategoriesByCategory(this.course.categoryId).subscribe(
      (subCategories) => {
        this.subCategories = subCategories;
      },
      (error) => {
        console.error('Error fetching sub-categories', error);
      }
    );
  }

  // Load the course details from the course service
  loadCourseDetails() {
    // Assuming the courseService has a method to get course details by ID
    this.courseService.getCourseById(this.courseId).subscribe(
      (course) => {
        this.course = course;
        // Call category change handler after loading the course to update sub-categories
        if (this.course.categoryId) {
          this.onCategoryChange(this.course.categoryId);
        }
      },
      (error) => {
        console.error('Error fetching course details', error);
      }
    );
  }

  // Update course details using the course service
  updateCourse() {
    this.courseService.updateCourse(this.courseId, this.course).subscribe(
      (response) => {
        console.log('Course updated successfully:', response);
        this.router.navigate(['/courses']);
      },
      (error) => {
        console.error('Error updating course:', error);
      }
    );
  }
}