import { Component, OnInit } from '@angular/core';
import { Course } from '../../lib/models/course.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import {
  CourseDetail,
  Lesson,
  Section,
} from '../../lib/models/CourseDetail.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../../lib/services/category.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';

@Component({
  selector: 'app-updatecoursedetails',
  imports: [CommonModule, FormsModule],
  templateUrl: './updatecoursedetails.component.html',
  styleUrl: './updatecoursedetails.component.css',
})
export class UpdatecoursedetailsComponent {}
