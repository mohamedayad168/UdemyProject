import { Component, OnInit } from '@angular/core';
import { Category } from '../../../../models/category.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../../environments/environment';
import { CommonModule } from '@angular/common';
import { Course } from '../../../../models/course.model';
import { CourseService } from '../../../../services/course.service';
import { CategoryService } from '../../../../services/category.service';
@Component({
  selector: 'app-categorysection',
  imports: [CommonModule],
  templateUrl: './categorysection.component.html',
  styleUrl: './categorysection.component.css',
})
export class CategorysectionComponent implements OnInit {
  categories: Category[] = [];
  courses: Course[] = [];
  categoryCourses: { [categoryId: number]: Course[] } = {}; // Stores courses for each category

  constructor(
 
  ) {}

  ngOnInit(): void {
   
  }

}