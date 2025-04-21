import { Component, Input } from '@angular/core';
import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';
import { Course } from '../../../../models/course.model';
import { CurrencyPipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-subcategory-course',
  imports: [NgbRatingModule, CurrencyPipe, RouterLink],
  templateUrl: './subcategory-course.component.html',
  styleUrl: './subcategory-course.component.css',
})
export class SubcategoryCourseComponent {
  @Input({ required: true }) course!: Course;

  ngOnInit() {}
}
