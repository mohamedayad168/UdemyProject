import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Category } from '../../lib/models/category.model';
import { CategoryService } from '../../lib/services/category.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-titelbage',
  imports: [FormsModule,CommonModule],
  templateUrl: './titelbage.component.html',
  styleUrl: './titelbage.component.css'
})
export class TitelbageComponent implements OnInit {
  courseTitle = '';
  remainingChars = 60;
  categories: Category[] = [];
  selectedCategoryId: number | null = null;

  constructor(private categoryService: CategoryService, private router: Router) {} 

  updateCharacterCount() {
    this.remainingChars = 60 - this.courseTitle.length;
  }

  get isFormValid(): boolean {
    return this.courseTitle.trim().length > 0 && this.selectedCategoryId !== null;
  }

  navigateToNextStep() {
    if (this.isFormValid) {
      this.router.navigate(['/createcourse/createcoursebage']);
    }
  }

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe({
      next: (data) => {
        this.categories = data;
      },
      error: (err) => {
        console.error('Error loading categories', err);
      }
    });
  }
}